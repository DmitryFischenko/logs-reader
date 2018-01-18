using Soti.LogReader.Entries;

namespace Soti.LogReader.Components.DbInstall
{
    public class DbInstallLogEntry : LogEntry
    {
        public bool IsDacpack => Level == Level.DacPac;
        public string DacpackStatus { get; set; }
    }
}
