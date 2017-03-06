using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Configuration;
using Soti.LogReader.Entries;
using Soti.LogReader.Parsers;

namespace Soti.LogReader.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FileLocateConfig
            {
                Directories = new List<string>() { @"C:\Dev\log-examples\dbinstall" },
                FileMasks = new List<string>() { @"DBInstall.log(.\d*)?" }
            };

            var logConfig = new LogConfiguration
            {
                FileLocateConfig = config,
                StartCheckers = new List<IEntryStartChecker>() { new DbInstallEntryStartChecker() },
                EntryParsers = new List<IEntryParser>() { new DbInstallEntryParser() }
            };

            var locator = new FileLocator();

            var files = locator.Locate(config).ToArray();
            files.OrderByDescending(fi => fi.LastWriteTime).ToList().ForEach(f => Console.WriteLine(@"Name: {0}. Created: {1}", f.Name, f.LastWriteTime));
            var logFileReader = new LogFileReader();
            var logFileProcesser = new LogFileProcessor();

            var extraParsers = new List<IEntryMessageParser> { new DacPacDeployStatusParser() };

            foreach (var fileInfo in files)
            {
                var lines = logFileReader.Read(fileInfo).Result;
                var entries = logFileProcesser.Process(lines.ToArray(), logConfig.StartCheckers.ToArray(), logConfig.EntryParsers.ToArray()).Cast<DbInstallLogEntry>().ToArray();

                foreach (var item in entries)
                {
                    extraParsers.ForEach(p => p.Parse(item));                    
                }                

                Console.WriteLine(@"File {0} has {1} entries. Errors {2}. Dacpack: {3}", fileInfo.Name, entries.Count(), entries.Count(e=>e.IsParseError), entries.Count(e=>e.IsDacpack));

                entries.Where(e => e.DacpackStatus == "SUCCESS").ToList().ForEach(e => Console.WriteLine(e.Message));

                var errors = entries.Where(e => e.IsParseError).ToList();
            }

            Console.ReadKey();
        }
    }
}
