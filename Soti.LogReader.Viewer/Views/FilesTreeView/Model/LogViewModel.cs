using System.Collections.Generic;
using System.Linq;

namespace Soti.LogReader.Viewer.Views.FilesTreeView.Model
{
    public class LogViewModel : ITreeViewItem
    {
        private readonly Log.Log _log;
        private readonly IEnumerable<ITreeViewItem> _children;

        public LogViewModel(Log.Log log)
        {
            _log = log;
            _children = _log.Files.Select(f => new FileViewModel(f)).ToList();
        }

        public string Title => _log.Title;
        public bool IsExpandable => _log.Files.Any();
        public IEnumerable<object> GetChildren()
        {
            return _children;
        }
    }
}
