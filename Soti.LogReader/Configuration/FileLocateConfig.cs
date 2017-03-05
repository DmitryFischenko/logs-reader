using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader.Configuration
{
    public class FileLocateConfig
    {
        public IEnumerable<string> Directories { get; set; }
        public IEnumerable<string> FileMasks { get; set; }
    }
}
