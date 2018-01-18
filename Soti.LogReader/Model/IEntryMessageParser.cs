using Soti.LogReader.Entries;

namespace Soti.LogReader.Model
{
    public interface IEntryMessageParser<T> where T : LogEntry
    {
        void Parse(T entry);
    }
}
