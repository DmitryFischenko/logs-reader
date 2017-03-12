using System.Collections.Generic;

namespace Soti.LogReader.Configuration
{
    public class FileLocateConfig
    {
        public IEnumerable<string> Directories { get; set; }
        public IEnumerable<string> FileMasks { get; set; }
    }
}
