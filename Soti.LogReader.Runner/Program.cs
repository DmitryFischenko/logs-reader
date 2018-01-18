using System;
using System.Collections.Generic;
using System.Linq;
using Soti.LogReader.Configuration;
using Soti.LogReader.Entries;
using Soti.LogReader.Locators;
using System.IO;
using Soti.LogReader.Model;
using Soti.LogReader.Components.DbInstall;
using Soti.LogReader.Common;

namespace Soti.LogReader.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var logConfig = new LogConfiguration<DbInstallLogEntry>
            {
                FileLocateConfig = new FileLocateConfig
                {
                    Directories = new List<string>() { @"C:\Dev\log-examples\dbinstall" },
                    FileMasks = new List<string>() { @"DBInstall.log(.\d*)?" }
                },
                StartCheckers = new List<IEntryStartChecker>() { new DbInstallEntryStartChecker() },
                EntryParsers = new List<IEntryParser<DbInstallLogEntry>>() { new DbInstallEntryParser() },
                MessageParsers = new List<IEntryMessageParser<DbInstallLogEntry>> { new DacPacDeployStatusParser() },
                Locators = new List<IEntryCollector> {new DacpacSuccessLocator(), new DbInstallStartLocator() }                
            };

            var locator = new FileLocator();

            var files = locator.Locate(logConfig.FileLocateConfig).ToArray();
            files.OrderByDescending(fi => fi.LastWriteTime).ToList().ForEach(f => Console.WriteLine(@"Name: {0}. Created: {1}", f.Name, f.LastWriteTime));
            var logFileReader = new LogFileReader();
            var logFileProcesser = new LogFileProcessor();         
          

            foreach (var fileInfo in files)
            {
                var lines = logFileReader.Read(fileInfo).Result;
                var entries = logFileProcesser.Process(lines.ToArray(), logConfig.StartCheckers.ToArray(), logConfig.EntryParsers.ToArray()).Cast<DbInstallLogEntry>().ToArray();

                var iterator = new EntryIterator<LogEntry>();
                iterator.SetList(entries);

                foreach (var item in entries)
                {
                    iterator.SetCurrent(item);
                    logConfig.MessageParsers.ToList().ForEach(p => p.Parse(item));                    
                    logConfig.Locators.ToList().ForEach(c=>c.Analize(item, iterator));
                }                

                Console.WriteLine(@"File {0} has {1} entries. Errors {2}. Dacpack: {3}", fileInfo.Name, entries.Count(), entries.Count(e=>e.IsParseError), entries.Count(e=>e.IsDacpack));

                entries.Where(e => e.DacpackStatus == "SUCCESS").ToList().ForEach(e => Console.WriteLine(e.Message));
            }

            var l = logFileReader.Read(files.First()).Result;
            var fileWatcher = new FileSystemWatcher();
            fileWatcher.Path = Path.GetDirectoryName(files.First().FullName);
            fileWatcher.Filter = files.First().Name;
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Changed += (source, e) =>
            {
                var newLines = logFileReader.Read().Result;
                Console.WriteLine("{0} lines added to the file.", newLines.Count());
            };


            Console.ReadKey();
        }
    }
}
