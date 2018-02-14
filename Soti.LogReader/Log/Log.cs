using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Configuration;
using Soti.LogReader.Model;

namespace Soti.LogReader.Log
{
    public class Log
    {
        private FileLocateConfig _fileLocateConfig;

        public void Init(FileLocateConfig fileLocateConfig)
        {
            _fileLocateConfig = fileLocateConfig;
        }
        public ComponentType Type { get; set; }
        public string Title { get; set; }
        public IEnumerable<LogFile> Files { get; set; }

        public string Group { get; set; }

        public void LocateFiles()
        {
            Files = new FileLocator().Locate(_fileLocateConfig).OrderByDescending(f => f.LastWriteTime).Select(f => new LogFile()
            {
                Type = Type,
                FileInfo = f
            }).ToList();
        }
    }
}
