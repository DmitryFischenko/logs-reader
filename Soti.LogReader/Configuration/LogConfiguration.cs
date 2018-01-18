using System.Collections.Generic;
using Soti.LogReader.Locators;
using Soti.LogReader.Model;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Configuration
{
    public class LogConfiguration<T> : ILogConfiguration<T> where T : LogEntry
    {
        public FileLocateConfig FileLocateConfig { get; set; }
        public IEnumerable<IEntryStartChecker> StartCheckers { get; set; }
        public IEnumerable<IEntryParser<T>> EntryParsers { get; set; }
        public IEnumerable<IEntryCollector> Locators { get ; set ; }
        public IEnumerable<IEntryMessageParser<T>> MessageParsers { get ; set ; }
    }
}
