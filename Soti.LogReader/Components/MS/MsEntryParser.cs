using System;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.MS
{
    public class MsEntryParser: IEntryParser<LogEntry>
    {
        public LogEntry Parse(string entry)
        {
            if (!DateTime.TryParse(entry.Substring(1, 10), out var _))
                return ParseDashFormat(entry);
            return ParseNormalFormat(entry);
        }

        private LogEntry ParseDashFormat(string entry)
        {
            var log = new LogEntry();
            log.TimeCreated = DateTime.Parse(entry.Substring(4, 23));

            var levelStart = 28;
            var levelEnd = entry.IndexOf(' ', levelStart);
            log.Level = (Level)Enum.Parse(typeof(Level), entry.Substring(levelStart, levelEnd - levelStart), true);

            int threadStart = entry.IndexOf('[', levelEnd) + 1;
            int threadEnd = entry.IndexOf(']', threadStart);
            var threadStr = entry.Substring(threadStart, threadEnd - threadStart);

            if (int.TryParse(threadStr, out var thread))
                log.Thread = thread;

            int messageStart = threadEnd + 2;
            if (entry[threadEnd + 3] == '[')
            {
                var componentStart = entry.IndexOf('[', threadEnd) + 1;
                var componentEnd = entry.IndexOf(']', componentStart);
                log.Component = entry.Substring(componentStart, componentEnd - componentStart);

                messageStart = componentEnd + 2;
            }

            log.Message = entry.Substring(messageStart).Trim().TrimStart('*');

            return log;
        }

        private LogEntry ParseNormalFormat(string entry)
        {
            var log = new LogEntry();

            log.TimeCreated = DateTime.Parse(entry.Substring(1, 23));

            var levelStart = 26;
            var levelEnd = entry.IndexOf(' ', levelStart);
            log.Level = (Level)Enum.Parse(typeof(Level), entry.Substring(levelStart, levelEnd - levelStart), true);



            var componentEnd = -1;

            if (entry[levelEnd + 2] == '[')
            {
                var componentStart = entry.IndexOf('[', levelEnd) + 1;
                componentEnd = entry.IndexOf(']', componentStart);
                log.Component = entry.Substring(componentStart, componentEnd - componentStart);
            }

            if (componentEnd != -1 && entry[componentEnd + 2] == '[')
            {
                var refStart = componentEnd + 3;
                var refEnd = entry.IndexOf(']', refStart);
                log.CorrelationId = entry.Substring(refStart, refEnd - refStart);
            }

            var threadStart = entry.IndexOf('(', levelEnd) + 1;
            var threadEnd = entry.IndexOf(')', threadStart);
            var threadStr = entry.Substring(threadStart, threadEnd - threadStart);

            int messageStart;
            if (int.TryParse(threadStr, out var thread))
            {
                log.Thread = thread;
                messageStart = threadEnd + 2;
            }
            else
            {
                messageStart = threadStart;
            }

            log.Message = entry.Substring(messageStart).Trim().TrimStart('*');
            return log;
        }
    }
}
