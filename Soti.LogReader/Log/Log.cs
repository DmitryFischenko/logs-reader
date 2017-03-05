using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Configuration;

namespace Soti.LogReader.Log
{
    public class Log
    {
        private FileLocateConfig _fileLocateConfig;

        public void Init(FileLocateConfig fileLocateConfig)
        {
            _fileLocateConfig = fileLocateConfig;
        }
        public string Title { get; set; }
        public IEnumerable<FileInfo> Files { get; set; }

        public void LocateFiles()
        {
            Files = new FileLocator().Locate(_fileLocateConfig);
        }
    }
}
