namespace Soti.LogReader.Model
{
    public interface IEntryStartChecker
    {
        bool Check(string line);
    }
}
