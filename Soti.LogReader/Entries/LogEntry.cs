using System;

namespace Soti.LogReader.Entries
{
    public class LogEntry
    {
        public Level Level { get; set; }
        public bool IsParseError { get; set; }
        public string FullText { get; set; }
        public DateTime? TimeCreated { get; set; }
    }
}
