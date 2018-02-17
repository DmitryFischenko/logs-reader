using Soti.LogReader.Locators;
using System;
using System.Collections;
using System.Collections.Generic;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Components.DbInstall
{
    public class DbInstallStartLocator : IEntryCollector
    {
        List<LogEntry> _entries = new List<LogEntry>();

        public void Analize(LogEntry entry, IEntryIterator<LogEntry> iterator)
        {            
            iterator.Previous();
            if (iterator.Current != null && (entry.TimeCreated - iterator.Current.TimeCreated).Value > TimeSpan.FromMinutes(5))
                _entries.Add(entry);
        }

        public IEntryIterator<LogEntry> GetLocator()
        {
            var iterator = new EntryIterator<LogEntry>();
            iterator.SetList(_entries.ToArray());
            return iterator;
        }
    }
}
