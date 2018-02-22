using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader.Viewer.Views.FilesTreeView.Model
{
    public class GroupViewModel : ITreeViewItem
    {
        private IEnumerable<Log.Log> _logs;
        private IEnumerable<ITreeViewItem> _children;

        public GroupViewModel(string title, IEnumerable<Log.Log> logs, ViewMode mode)
        {
            _logs = logs;
            _children = _logs.Select<Log.Log, ITreeViewItem>(l =>
            {
                if (l.Files.Count() == 1)
                    return new FileViewModel(l.Files.First());
                return mode == ViewMode.TreeView ? (ITreeViewItem)new LogViewModel(l) : (ITreeViewItem)new FileViewModel(l.Files.First());
            }).ToList();

            Title = title;
        }

        public string Title { get; }
        public bool IsExpandable => _logs.Any();

        public IEnumerable<object> GetChildren()
        {

            return _children;
        }

        public string Tooltip => string.Empty;
    }
}
