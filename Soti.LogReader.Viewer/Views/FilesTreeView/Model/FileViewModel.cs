using System.Collections.Generic;
using Soti.LogReader.Log;

namespace Soti.LogReader.Viewer.Views.FilesTreeView.Model
{
    public class FileViewModel:ITreeViewItem
    {
        private readonly LogFile _fileInfo;

        public FileViewModel(LogFile fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public LogFile LogFile => _fileInfo;

        public string Title => _fileInfo.FileInfo.Name;
        public bool IsExpandable => false;
        public IEnumerable<object> GetChildren()
        {
            return null;
        }

        public string Tooltip => _fileInfo.FileInfo.FullName;
    }
}
