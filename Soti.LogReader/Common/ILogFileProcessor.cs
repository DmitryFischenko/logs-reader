using System.Collections.Generic;
using Soti.LogReader.Model;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Common
{
    public interface ILogFileProcessor
    {
        IEnumerable<T> Process<T>(string fileName, string[] lines, IEntryStartChecker[] startCheckers, IEntryParser<T>[] entryParsers) where T : LogEntry;
    }
}
