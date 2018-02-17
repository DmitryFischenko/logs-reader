using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Configuration
{
    public class ConfigurationProvider
    {
        private static LogConfigEntry[] _logs;

        public static LogConfigEntry[] Get()
        {
            if (_logs != null)
                return _logs;

            _logs = new LogConfigEntry[]
            {
                new LogConfigEntry()
                {
                    Type = ComponentType.DbInstall,
                    Title = "DbInstall",
                    Paths = new[]{ @"C://"},
                    FileMasks = new [] {@"DBInstall.log(.\d*)?"},
                    Group = "Installer"
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.McInstall,
                    Title = "McInstall",
                    // Paths = new[]{ @"C:\Dev\logs-reader\data"},
                    Paths = new[]{ @"{tmp}"},
                    FileMasks = new [] {@"McInstall.log"},
                    Group = "Installer"
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.MS,
                    Title = "ManagementService",
                    Paths = new[] {@"C:\ProgramData\SOTI"} ,
                    FileMasks = new [] { @"ManagementService.log(.\d*)?" }
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.DSE,
                    Title = "DSE",
                    Paths = new[] {@"C:\ProgramData\SOTI"} ,
                    FileMasks = new [] { @"DeploymentServerExtensions.log(.\d*)?" }
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.UpgradeExtentions,
                    Title = "UpgradeExtensions",
                    Paths = new[] {@"C:\ProgramData\SOTI"} ,
                    FileMasks = new [] { @"MCUpgradeHandler.log" }
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.DS,
                    Title = "DS",
                    Paths = new[] {@"C:\ProgramData\SOTI"} ,
                    FileMasks = new [] { @"MCDeplSvr.log(old.\d*)?" }
                },
                new LogConfigEntry()
                {
                    Type = ComponentType.CLA,
                    Title = "CloudLinkAgent",
                    Paths = new[] {@"C:\ProgramData\SOTI"} ,
                    FileMasks = new [] { @"CloudLinkAgent.log" }
                }
            };

            return _logs;
        }

        public static ComponentType GetTypeByFileName(string fileName)
        {
            foreach (var logConfigEntry in _logs)
            {
                if (Regex.IsMatch(fileName, logConfigEntry.FileMasks.First()))
                    return logConfigEntry.Type;
            }

            return ComponentType.NotDefined;
        }
    }
}
