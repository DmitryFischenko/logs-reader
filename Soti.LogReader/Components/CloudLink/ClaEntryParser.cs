using System;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.CloudLink
{
    public class ClaEntryParser : IEntryParser<LogEntry>
    {
        public LogEntry Parse(string entry)
        {
            var log = new LogEntry();
            var date = entry.Substring(1, 23);
            log.TimeCreated = DateTime.Parse(date);

            var levelStart = entry.IndexOf(' ', 25) + 1;
            var levelEnd = entry.IndexOf(' ', levelStart);
            var level = entry.Substring(levelStart, levelEnd - levelStart);
            log.Level = (Level)Enum.Parse(typeof(Level), level, true);

            log.Message = entry.Substring(entry.IndexOf(':', levelEnd) + 1);
            return log;
        }
    }
}
