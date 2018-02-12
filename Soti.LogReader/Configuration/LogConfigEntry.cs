using Soti.LogReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader.Configuration
{
    // TODO: Find a better name
    public class LogConfigEntry
    {
        public string Group { get; set; }
        public ComponentType Type { get; set; }
        public string[] Paths { get; set; }
    }
}
