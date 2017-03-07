using Soti.LogReader.Entries;
using Soti.LogReader.Locators;

namespace Soti.LogReader.Parsers
{
    public interface IEntryParser
    {
        LogEntry Parse(string entry);
    }
}
