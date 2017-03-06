using Soti.LogReader.Entries;

namespace Soti.LogReader.Parsers
{
    public class DacPacDeployStatusParser : IEntryMessageParser
    {
        public void Parse(DbInstallLogEntry entry)
        {
            if (entry.IsDacpack == false)
                return;

            if (entry.Message.StartsWith("SUCCESS:"))
                entry.DacpackStatus = "SUCCESS";
        }
    }
}
