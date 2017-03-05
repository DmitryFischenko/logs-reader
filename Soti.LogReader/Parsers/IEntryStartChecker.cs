namespace Soti.LogReader.Parsers
{
    public interface IEntryStartChecker
    {
        bool Check(string line);
    }
}
