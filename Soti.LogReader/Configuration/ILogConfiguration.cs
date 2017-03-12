using System.Collections.Generic;
using Soti.LogReader.Parsers;

namespace Soti.LogReader.Configuration
{
    public interface ILogConfiguration
    {
        FileLocateConfig FileLocateConfig { get; set; }
        IEnumerable<IEntryStartChecker> StartCheckers { get; set; }
    }
}
