using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Parsers;

namespace Soti.LogReader
{
    public class LogFileProcessor : ILogFileProcessor
    {
        public IEnumerable<LogEntry> Process(string[] lines ,IEntryStartChecker[] startCheckers, IEntryParser[] entryParsers )
        {
            var entires = new List<LogEntry>();

            var buffer = new List<string>();
            for(var i = 0; i < lines.Length; i ++)
            {
                var line = lines[i];

                if (!startCheckers.Any(s => s.Check(line)) || buffer.Any() == false )
                {
                    buffer.Add(line);
                    continue;
                }
                entires.Add(Parse(string.Join(Environment.NewLine, buffer), entryParsers));
                buffer.Clear();
                buffer.Add(line);
            }

            entires.Add(Parse(string.Join(Environment.NewLine, buffer), entryParsers));

            return entires;
        }

        private LogEntry Parse(string str, IEntryParser[] parsers)
        {
            LogEntry entry = null;
            foreach (var entryParser in parsers)
            {
                entry = entryParser.Parse(str);
                if (entry.IsParseError == false)
                    break;
            }
            return entry;
        }
    }
}
