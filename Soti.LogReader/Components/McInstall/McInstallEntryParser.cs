using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.McInstall
{
    public class McInstallEntryParser : IEntryParser<LogEntry>
    {
        public LogEntry Parse(string log)
        {
            var entry = new LogEntry();
            var secondSpaceIdx = log.IndexOf(' ', log.IndexOf(' ') + 1);

            entry.TimeCreated = DateTime.Parse(log.Substring(0, secondSpaceIdx - 1));
            entry.Message = log.Substring(secondSpaceIdx);
            return entry;
        }
    }
}
