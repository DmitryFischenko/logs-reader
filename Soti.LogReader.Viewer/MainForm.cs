using Soti.LogReader.Configuration;
using Soti.LogReader.Viewer.Views;
using System.Windows.Forms;
using Soti.CommTracer;
using Soti.LogReader.Viewer.Modules;
using Soti.LogReader.Viewer.Views.CommTracerView;
using Soti.LogReader.Viewer.Views.FilesTreeView;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            Init();

            ConfigureView();
        }

        private void Init()
        {
            ViewManager.Instance.Init();

            EventBus.Bus.GetEvent<AddView>()
                .Subscribe((view) => view.Show(dockPanel, DockState.Document));

            EventBus.Bus.GetEvent<ActivateView>()
                .Subscribe((view) => view.Activate());
        }

        private void ConfigureView()
        {
            dockPanel.DockLeftPortion = 200;

            dockPanel.DockRightPortion = 400;

            var fileTreePanel = new FilesTreeView();
            fileTreePanel.Show(dockPanel, DockState.DockLeft);

            var entryView = new EntryTextView();
            entryView.Show(dockPanel, DockState.DockRight);
        }

        private void btnConfigureLogs_Click(object sender, System.EventArgs e)
        {
            LoggingConfigManager.TurnOffBufferedLogAppenders();
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            var commTracerView = new CommTracerView();
            commTracerView.Show(dockPanel, DockState.Document);
        }
    }
}
