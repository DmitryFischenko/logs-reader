using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
    }
}
