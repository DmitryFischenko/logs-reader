using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Components.CloudLink;
using Soti.LogReader.Components.DbInstall;
using Soti.LogReader.Components.DS;
using Soti.LogReader.Components.McInstall;
using Soti.LogReader.Components.MS;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Common
{
    public class ParsersFactory
    {
        public static IEntryParser<LogEntry>[] GetEntryParsers(ComponentType component)
        {
            switch (component)
            {
                case ComponentType.McInstall:
                    return new IEntryParser<LogEntry>[] {new McInstallEntryParser()};
                case ComponentType.DbInstall:
                    return new IEntryParser<LogEntry>[] {new DbInstallEntryParser()};
                case ComponentType.MS:
                case ComponentType.DSE:
                case ComponentType.UpgradeExtentions:
                    return new IEntryParser<LogEntry>[] {new MsEntryParser()};
                case ComponentType.DS:
                    return new IEntryParser<LogEntry>[] {new DsEntryParser(), };
                case ComponentType.CLA:
                    return new IEntryParser<LogEntry>[] {new ClaEntryParser(), };

                default:
                    return null;
            }
        }

        public static IEntryStartChecker[] GetEntryStartCheckers(ComponentType component)
        {
            switch (component)
            {
                case ComponentType.McInstall:
                    return new[] {new McInstallEntryStartChecker()};
                case ComponentType.DbInstall:
                    return new[] {new DbInstallEntryStartChecker()};
                case ComponentType.MS:
                case ComponentType.DSE:
                case ComponentType.UpgradeExtentions:
                    return new[] {new MsEntryStartChecker()};
                case ComponentType.DS:
                    return new[] {new DsEntryStartChecker(),};
                case ComponentType.CLA:
                    return new[] {new ClaEntryStartChecker(),};
                default:
                    return null;
            }
        }
    }
}
