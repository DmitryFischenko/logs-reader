using Soti.LogReader.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader
{
    public interface IEntryMessageParser
    {
        void Parse(DbInstallLogEntry entry);
    }
}
