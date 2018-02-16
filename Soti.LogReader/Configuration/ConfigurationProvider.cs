using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Configuration
{
    public class ConfigurationProvider
    {
        public LogConfigEntry[] Get()
        {
            return new LogConfigEntry[]
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
                    Paths = new[]{ @"C:\Dev\logs-reader\data"},
                    FileMasks = new [] {@"McInstall.log"},
                    Group = "Installer"
                }
            };
        }
    }
}
