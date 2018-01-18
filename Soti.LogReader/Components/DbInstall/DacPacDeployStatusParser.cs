using Soti.LogReader.Model;

namespace Soti.LogReader.Components.DbInstall
{
    public class DacPacDeployStatusParser : IEntryMessageParser<DbInstallLogEntry>
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
