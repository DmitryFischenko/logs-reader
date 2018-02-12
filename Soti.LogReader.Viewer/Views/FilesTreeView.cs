using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soti.LogReader.Viewer.Views
{
    public partial class FilesTreeView : UserControl
    {
        enum ViewMode
        {
            LastFiles,
            TreeView
        }

        private ViewMode Mode = ViewMode.LastFiles;            

        public FilesTreeView()
        {
            InitializeComponent();
        }

        private void viewModeButton_Click(object sender, EventArgs e)
        {
            if (Mode == ViewMode.LastFiles)
            {
                Mode = ViewMode.TreeView;
                viewModeButton.Image = Properties.Resources.list;
                viewModeButton.ToolTipText = "Latest files";
            }
            else
            {
                Mode = ViewMode.LastFiles;
                viewModeButton.Image = Properties.Resources.hierarchy;
                viewModeButton.ToolTipText = "Tree view with all files";
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
        }
    }
}
