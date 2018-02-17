using Soti.LogReader.Entries;

namespace Soti.LogReader.Model
{
    public interface IEntryParser<out T> where T : LogEntry
    {
        T Parse(string entry);
    }
}
