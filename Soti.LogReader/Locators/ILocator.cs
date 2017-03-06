using Soti.LogReader.Entries;

namespace Soti.LogReader.Locators
{
    public interface ILocator
    {
        void Analize(LogEntry entry);

        LogEntry Current { get; }

        void MoveNext();
        void MoveForward();
        void MoveLast();
        void Reset();
    }
}
