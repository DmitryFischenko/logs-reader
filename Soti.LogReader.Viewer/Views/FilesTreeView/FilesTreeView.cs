using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Soti.LogReader.Configuration;
using Soti.LogReader.Log;
using Soti.LogReader.Model;
using Soti.LogReader.Viewer.Views.FilesTreeView.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer.Views.FilesTreeView
{
    public partial class FilesTreeView : DockContent
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
            Text = "Log List";
            var logs = ConfigurationProvider.Get();
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
                if (l.Files.Any())
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

            var logs = new List<Log.Log>();

            foreach (var dlgFileName in dlg.FileNames)
            {
                var component = ConfigurationProvider.GetTypeByFileName(dlgFileName);
                if (component == ComponentType.NotDefined)
                    continue;
                var l = new Log.Log()
                {
                   Type = component,
                   Title = "adfadf"
                    
                };
                l.Files = new LogFile[] { new LogFile()
                    {
                        Type = component,
                        FileInfo = new FileInfo(dlgFileName)
                    } 
                } ;

                logs.Add(l);
            }

            var group = new GroupViewModel("Added files", logs, ViewMode.TreeView);
            treeListFiles.AddObject(group);
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

        private void FilesTreeView_Load(object sender, EventArgs e)
        {

        }

        private void treeListFiles_CanDrop(object sender, OlvDropEventArgs e)
        {

        }

        private void treeListFiles_Dropped(object sender, OlvDropEventArgs e)
        {

        }

        private void treeListFiles_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void treeListFiles_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void FilesTreeView_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
