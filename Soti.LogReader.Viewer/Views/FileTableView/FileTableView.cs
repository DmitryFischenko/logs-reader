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

namespace Soti.LogReader.Viewer.Views.FileTableView
{
    public partial class FileTableView : DockContent
    {
        private readonly LogFile _logFile;

        public FileTableView(LogFile logFile)
        {
            InitializeComponent();

            _logFile = logFile;
            Text = _logFile.FileInfo.Name;
            LoadContent();
        }

        public async void LoadContent()
        {
            var lines = await new LogFileReader().Read(_logFile.FileInfo);
            var entries = new LogFileProcessor()
                .Process(
                    lines.ToArray(),
                    new IEntryStartChecker[] {new McInstallEntryStartChecker()},
                    new IEntryParser<LogEntry>[] {new McInstallEntryParser()}).ToArray();

            fastObjectListView.SetObjects(entries);
            fastObjectListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
    }
}
