using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Soti.LogReader.Common;
using Soti.LogReader.Entries;
using Soti.LogReader.Log;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using Soti.LogReader.Components.DbInstall;
using Soti.LogReader.Locators;

namespace Soti.LogReader.Viewer.Views.FileTableView
{
    public partial class FileTableView : DockContent
    {
        private readonly LogFile _logFile;
        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();

        public FileTableView(LogFile logFile)
        {
            InitializeComponent();
            FormClosing += (o, e) =>
            {
                _cancellationToken.Cancel();
                fastObjectListView.ClearObjects();
                fastObjectListView.Dispose();
                EventBus.Bus.GetEvent<ViewRemoved>().Publish(this);
                this.DestroyHandle();
            };

            FormClosed += (o, e) =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            };

            EventBus.Bus.GetEvent<FilterByText>().Subscribe((filter) =>
            {
                filterTextBox.Text = filter;
                Filter();
            });

            fastObjectListView.RowFormatter = item =>
            {
                if (item.RowObject == null)
                    return;
                var level = ((LogEntry)item.RowObject).Level;
                switch (level)
                {
                    case Level.Error:
                    case Level.Fatal:
                        {
                            item.ForeColor = Color.Red;
                            break;
                        }
                    case Level.Warn:
                    case Level.Warning:
                    {
                        {
                            item.ForeColor = Color.OrangeRed;
                            break;
                        }
                        }
                }
            };

            fastObjectListView.HideOverlays();

            _logFile = logFile;
            Text = _logFile.FileInfo.Name;
            LoadContent();
            UpdateLocators();
        }

        private async void UpdateLocators()
        {
            await Task.Run(() =>
            {
                var iterator = new EntryIterator<LogEntry>();
                iterator.SetList(fastObjectListView.Objects.Cast<LogEntry>().ToArray());
                var l = new DbInstallStartLocator();
                

            });
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        public async void LoadContent()
        {
            SetLoadingState(true);

            LogEntry[] entries = null;

            await Task.Run(() =>
            {
                //var lines = new LogFileReader().Read(_logFile.FileInfo).Result;
                entries = new LogFileProcessor()
                    .Process(
                        _logFile.FileInfo.FullName,
                        null,
                        ParsersFactory.GetEntryStartCheckers(_logFile.Type),
                        ParsersFactory.GetEntryParsers(_logFile.Type)).ToArray();
            });

            if (_cancellationToken.IsCancellationRequested)
                return;

            entriesNumberTxt.Text = $"Entries: {entries.Length}";
            fastObjectListView.SetObjects(entries);
            fastObjectListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            SetLoadingState(false);
        }

        private void SetLoadingState(bool isLoading)
        {
            if (isLoading)
            {
                fastObjectListView.OverlayText.Text = "Loading...";
                fastObjectListView.RefreshOverlays();
                fastObjectListView.Update();
                Text = "Loading...";
            }
            else
            {
                fastObjectListView.OverlayText.Text = string.Empty;
                fastObjectListView.RefreshOverlays();
                fastObjectListView.Update();
                Text = _logFile.FileInfo.Name;
            }
        }

        private void filterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter();
        }

        private void Filter()
        {

            fastObjectListView.ModelFilter = TextMatchFilter.Contains(fastObjectListView, filterTextBox.Text);
        }

        private void FileTableView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                filterTextBox.Focus();
            }
        }

        private void clearFilterBtn_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = null;
            var selected = fastObjectListView.SelectedObject;
            fastObjectListView.ModelFilter = null;
            if (selected != null)
            {
                fastObjectListView.SelectObject(selected);
                fastObjectListView.EnsureModelVisible(selected);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadContent();
        }

        private void prevErrorBtn_Click(object sender, EventArgs e)
        {
            var current = fastObjectListView.FocusedItem?.Index ?? 0;
            for (var i = current - 1; i >= 0; i--)
            {
                if (fastObjectListView.GetModelObject(i) is LogEntry log && log.Level == Level.Error)
                {
                    fastObjectListView.SelectedObject = log;
                    fastObjectListView.EnsureModelVisible(log);
                    return;
                }
            }
        }

        private void nextErrorBtn_Click(object sender, EventArgs e)
        {
            var current = fastObjectListView.FocusedItem?.Index ?? 0;
            for (var i = current + 1; i < fastObjectListView.GetItemCount(); i++)
            {
                if (fastObjectListView.GetModelObject(i) is LogEntry log && log.Level == Level.Error)
                {
                    fastObjectListView.SelectedObject = log;
                    fastObjectListView.EnsureModelVisible(log);
                    return;
                }
            }
        }

        private void fastObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            if (fastObjectListView.SelectedObject is LogEntry selected)
                EventBus.Bus.GetEvent<LogEntrySelected>().Publish(selected);
        }

        private void fastObjectListView_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
                return;

            var model = e.Model as LogEntry;
            if (model == null)
                return;

            if (e.Column == colThread)
            {
                if (model.Thread > 0)
                    fastObjectListView.ModelFilter = new ModelFilter((entry) => ((LogEntry)entry).Thread == model.Thread);
            }

            if (e.Column == colComponent)
            {
                if (!string.IsNullOrEmpty(model.Component))   
                    fastObjectListView.ModelFilter = new ModelFilter((entry) => ((LogEntry)entry).Component == model.Component);
            }

            if (e.Column == colCorId)
            {
                if (!string.IsNullOrEmpty(model.CorrelationId))
                    fastObjectListView.ModelFilter = new ModelFilter((entry) => ((LogEntry)entry).CorrelationId == model.CorrelationId);
            }
        }
    }
}
