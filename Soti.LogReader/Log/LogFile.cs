using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Log
{
    public class LogFile
    {
        public ComponentType Type { get; set; }
        public FileInfo FileInfo { get; set; }
    }
}
