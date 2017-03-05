using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Parsers;

namespace Soti.LogReader.Configuration
{
    public class LogConfiguration : ILogConfiguration
    {
        public FileLocateConfig FileLocateConfig { get; set; }
        public IEnumerable<IEntryStartChecker> StartCheckers { get; set; }
        public IEnumerable<IEntryParser> EntryParsers { get; set; }
    }
}
