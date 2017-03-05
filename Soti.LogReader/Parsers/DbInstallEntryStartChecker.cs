namespace Soti.LogReader.Parsers
{
    /// <summary>
    /// Example of the entry start:    2016-11-24 12:16:23.021:
    /// </summary>
    public class DbInstallEntryStartChecker : IEntryStartChecker
    {
        public bool Check(string line)
        {
            return CheckRegular(line) || CheckDacPack(line);
        }

        private bool CheckRegular(string line)
        {
            return line.Length > 11 && line[4] == '/' && line[7] == '/' && line[13] == ':';
        }

        private bool CheckDacPack(string line)
        {
            return line.Length > 11 && line[4] == '-' && line[7] == '-' && line[13] == ':';
        }
    }
}
