using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Soti.LogReader.Common;
using Soti.LogReader.Components.DbInstall;
using Soti.LogReader.Components.McInstall;
using Soti.LogReader.Entries;
using Soti.LogReader.Log;
using Soti.LogReader.Model;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;

namespace Soti.LogReader.Viewer.Views.FileTableView
{
    public partial class FileTableView : DockContent
    {
        private readonly LogFile _logFile;
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private CancellationToken token;


        public FileTableView(LogFile logFile)
        {
            InitializeComponent();
            FormClosing += (o, e) => cancellationToken.Cancel();
            fastObjectListView.HideOverlays();

            _logFile = logFile;
            Text = _logFile.FileInfo.Name;
            LoadContent();
        }

        public async void LoadContent()
        {
            fastObjectListView.OverlayText.Text = "Loading...";
            fastObjectListView.RefreshOverlays();
            fastObjectListView.Update();
            Text = "Loading...";
            
            LogEntry[] entries = null;            

            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                var lines = new LogFileReader().Read(_logFile.FileInfo).Result;
                entries = new LogFileProcessor()
                    .Process(
                        lines.ToArray(),
                        new IEntryStartChecker[] { new McInstallEntryStartChecker() },
                        new IEntryParser<LogEntry>[] { new McInstallEntryParser() }).ToArray();
            });

            if (cancellationToken.IsCancellationRequested)
                return;

            fastObjectListView.SetObjects(entries);
            fastObjectListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fastObjectListView.OverlayText.Text = string.Empty;
            fastObjectListView.RefreshOverlays();
            fastObjectListView.Update();
            Text = _logFile.FileInfo.Name;
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
            fastObjectListView.ModelFilter = null;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadContent();
        }
    }
}
