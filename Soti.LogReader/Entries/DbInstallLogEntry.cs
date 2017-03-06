using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader.Entries
{
    public class DbInstallLogEntry : LogEntry
    {
        public bool IsDacpack => Level == Level.DacPac;
        public string DacpackStatus { get; set; }
    }
}
