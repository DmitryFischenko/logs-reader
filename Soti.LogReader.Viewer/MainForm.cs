using Soti.LogReader.Configuration;
using Soti.LogReader.Viewer.Views;
using System.Windows.Forms;
using Soti.LogReader.Viewer.Views.FilesTreeView;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            Init();

            ConfigureView();
        }

        private void Init()
        {

        }

        private void ConfigureView()
        {
            var fileTreePanel = new DockContent() { Text = "Log Files" };
            fileTreePanel.Controls.Add(new FilesTreeView()
            {
                Dock = DockStyle.Fill
            });
            fileTreePanel.Show(dockPanel, DockState.DockLeft);
        }
    }
}
