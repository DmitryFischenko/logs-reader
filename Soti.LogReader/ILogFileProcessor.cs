using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Parsers;

namespace Soti.LogReader
{
    public interface ILogFileProcessor
    {
        IEnumerable<LogEntry> Process(string[] lines, IEntryStartChecker[] startCheckers, IEntryParser[] entryParsers);
    }
}
