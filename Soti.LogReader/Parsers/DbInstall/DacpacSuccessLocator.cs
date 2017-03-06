using Soti.LogReader.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Parsers.DbInstall
{
    public class DacpacSuccessLocator : ILocator
    {
        List<LogEntry> entries = new List<LogEntry>();

        public LogEntry Current => throw new NotImplementedException();

        public void Analize(LogEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            var dbInstallLogEntry = entry as DbInstallLogEntry;
            if (dbInstallLogEntry == null)
                throw new InvalidOperationException("Entry of wrong type provided");


            if (dbInstallLogEntry.DacpackStatus == "SUCCESS")
            {
                entries.Add(entry);
            }
        }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }

        public void MoveLast()
        {
            throw new NotImplementedException();
        }

        public void MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
