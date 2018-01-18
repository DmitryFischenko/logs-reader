using Soti.LogReader.Locators;
using System;
using System.Collections.Generic;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Components.DbInstall
{
    public class DacpacSuccessLocator : IEntryCollector
    {
        readonly List<LogEntry> _entries = new List<LogEntry>();

        public void Analize(LogEntry entry, IEntryIterator<LogEntry> iterator)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            var dbInstallLogEntry = entry as DbInstallLogEntry;
            if (dbInstallLogEntry == null)
                throw new InvalidOperationException("Entry of wrong type provided");


            if (dbInstallLogEntry.DacpackStatus == "SUCCESS")
            {
                _entries.Add(entry);
            }
        }

        public IEntryIterator<LogEntry> GetLocator()
        {
            var locator = new EntryIterator<LogEntry>();
            locator.SetList(_entries.ToArray());
            return locator;
        }
    }
}
