using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.DS
{
    public class DsEntryParser: IEntryParser<LogEntry>
    {
        public LogEntry Parse(string entry)
        {
            var log = new LogEntry();
            var date = entry.Substring(0, 23).Replace(',', '.');
            log.TimeCreated = DateTime.Parse(date);

            var threadStart = entry.IndexOf('(', 23) + 1;
            var threadEnd = entry.IndexOf(')', threadStart);
            
            if (int.TryParse(entry.Substring(threadStart, threadEnd-threadStart), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var thread ))
                log.Thread = thread;

            int levelStart;
            int levelEnd;


            if (entry[threadEnd + 3] == '\t')
            {
                levelStart = threadEnd + 4;
                levelEnd = entry.IndexOf(':', levelStart);
            }
            else
            {
                levelStart = entry.IndexOf('[', 23) + 1;
                levelEnd = entry.IndexOf(']', levelStart);
            }

            var level = entry.Substring(levelStart, levelEnd - levelStart);
            log.Level = (Level)Enum.Parse(typeof(Level), level, true);

            log.Message = entry.Substring(levelEnd + 2);
            return log;
        }
    }
}
