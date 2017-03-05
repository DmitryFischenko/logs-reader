using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Parsers;

namespace Soti.LogReader.Configuration
{
    public interface ILogConfiguration
    {
        FileLocateConfig FileLocateConfig { get; set; }
        IEnumerable<IEntryStartChecker> StartCheckers { get; set; }
    }
}
