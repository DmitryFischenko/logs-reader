using System;
using System.Collections.Generic;

namespace Soti.LogReader.Entries
{
    public class LogEntry
    {
        public Level Level { get; set; }
        public bool IsParseError { get; set; }

        /// <summary>
        /// The values is set only in case of parser error. Otherwise holds null value.
        /// </summary>
        public string FullText { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string Message { get; set; }

        public Dictionary<string, string> ExtraInfo => new Dictionary<string, string>();
    }
}
