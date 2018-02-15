﻿using Soti.LogReader.Configuration;
using Soti.LogReader.Viewer.Views;
using System.Windows.Forms;
using Soti.LogReader.Viewer.Views.FilesTreeView;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer
{
    public partial class frmMain : Form
    {
        ViewManager _manager = new ViewManager();

        public frmMain()
        {
            InitializeComponent();

            Init();

            ConfigureView();
        }

        private void Init()
        {
            EventBus.Bus.GetEvent<AddView>()
                .Subscribe((view) => view.Show(dockPanel, DockState.Document));

            EventBus.Bus.GetEvent<ActivateView>()
                .Subscribe((view) => view.Activate());
        }

        private void ConfigureView()
        {
            dockPanel.DockLeftPortion = 200;

            var fileTreePanel = new FilesTreeView();
            fileTreePanel.Show(dockPanel, DockState.DockLeft);
        }
    }
}
