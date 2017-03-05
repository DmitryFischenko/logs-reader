using Soti.LogReader.Entries;

namespace Soti.LogReader.Parsers
{
    public interface IEntryParser
    {
        LogEntry Parse(string entry);
    }
}
