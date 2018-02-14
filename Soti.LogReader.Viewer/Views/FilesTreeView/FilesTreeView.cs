﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Soti.LogReader.Configuration;
using Soti.LogReader.Viewer.Views.FilesTreeView.Model;

namespace Soti.LogReader.Viewer.Views.FilesTreeView
{
    public partial class FilesTreeView : UserControl
    {
        private List<Log.Log> _logs = new List<Log.Log>();

        private ViewMode _mode = ViewMode.LastFiles;            

        public FilesTreeView()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            var logs = new ConfigurationProvider().Get();
            foreach (var log in logs)
            {
                var l = new Log.Log();
                l.Init(new FileLocateConfig()
                {
                    Directories = log.Paths,
                    FileMasks = log.FileMasks
                });
                l.Type = log.Type;
                l.Title = log.Title;
                l.Group = log.Group;
                l.LocateFiles();
                _logs.Add(l);
            }

            colTitle.AspectGetter = o => ((ITreeViewItem) o).Title;
            treeListFiles.ChildrenGetter = o => ((ITreeViewItem) o).GetChildren();
            treeListFiles.CanExpandGetter = o => ((ITreeViewItem) o).IsExpandable;

            
            treeListFiles.HyperlinkStyle.Visited.ForeColor = treeListFiles.HyperlinkStyle.Normal.ForeColor;

            BuildModel();
        }

        private void BuildModel()
        {
            var viewItems = new List<ITreeViewItem>();
            var groups = _logs.GroupBy(l => l.Group);
            foreach (var group in groups)
            {
                if (group.Key == null)
                {
                    if (_mode == ViewMode.TreeView)
                        viewItems.AddRange(group.Select(l => new LogViewModel(l)));
                    else
                        viewItems.AddRange(group.Select(l => new FileViewModel(l.Files.First())));
                }
                else
                    viewItems.Add(new GroupViewModel(group.Key, group, _mode));
            }

            treeListFiles.SetObjects(viewItems);
            treeListFiles.AutoResizeColumns();
            treeListFiles.ExpandAll();
        }

        private void viewModeButton_Click(object sender, EventArgs e)
        {
            if (_mode == ViewMode.LastFiles)
            {
                _mode = ViewMode.TreeView;
                viewModeButton.Image = Properties.Resources.list;
                viewModeButton.ToolTipText = "Latest files";
            }
            else
            {
                _mode = ViewMode.LastFiles;
                viewModeButton.Image = Properties.Resources.hierarchy;
                viewModeButton.ToolTipText = "Tree view with all files";
            }

            BuildModel();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
        }

        private void treeListFiles_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if(!(e.Model is FileViewModel fileViewModel))
                return;

            EventBus.Bus.GetEvent<LogFileDoubleClick>().Publish(fileViewModel.LogFile);
        }

        private void treeListFiles_IsHyperlink(object sender, BrightIdeasSoftware.IsHyperlinkEventArgs e)
        {
            e.IsHyperlink = e.Model is FileViewModel;
        }
    }
}