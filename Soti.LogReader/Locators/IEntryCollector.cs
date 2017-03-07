using Soti.LogReader.Entries;

namespace Soti.LogReader.Locators
{
    public interface IEntryCollector
    {
        void Analize(LogEntry entry, IEntryIterator<LogEntry> iterator);

        IEntryIterator<LogEntry> GetLocator();
    }
}
