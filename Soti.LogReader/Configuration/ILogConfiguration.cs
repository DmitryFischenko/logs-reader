using System.Collections.Generic;
using Soti.LogReader.Locators;
using Soti.LogReader.Model;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Configuration
{
    public interface ILogConfiguration<T> where T : LogEntry
    {
        FileLocateConfig FileLocateConfig { get; set; }
        IEnumerable<IEntryStartChecker> StartCheckers { get; set; }
        IEnumerable<IEntryParser<T>> EntryParsers { get; set; }
        IEnumerable<IEntryCollector> Locators { get; set; }
        IEnumerable<IEntryMessageParser<T>> MessageParsers { get; set; }
    }
}
