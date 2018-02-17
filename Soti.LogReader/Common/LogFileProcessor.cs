using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Common
{
    public class LogFileProcessor : ILogFileProcessor
    {
        public IEnumerable<T> Process<T>(string fileName, string[] lines ,IEntryStartChecker[] startCheckers, IEntryParser<T>[] entryParsers ) where T : LogEntry
        {
            var entires = new List<T>();

            var buffer = new List<string>();
            //for(var i = 0; i < lines.Length; i ++)
            //{
            //    var line = lines[i];

            //    if (!startCheckers.Any(s => s.Check(line)) || buffer.Any() == false )
            //    {
            //        buffer.Add(line);
            //        continue;
            //    }
            //    entires.Add(Parse(string.Join(Environment.NewLine, buffer), entryParsers));
            //    buffer.Clear();
            //    buffer.Add(line);
            //}
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream))
                {
                    do
                    {
                        var line = reader.ReadLine();
                        if (!startCheckers.Any(s => s.Check(line)) || buffer.Any() == false)
                        {
                            buffer.Add(line);
                            continue;
                        }
                        entires.Add(Parse(string.Join(Environment.NewLine, buffer), entryParsers));
                        buffer.Clear();
                        buffer.Add(line);
                    } while (!reader.EndOfStream);
                }
            }

            entires.Add(Parse(string.Join(Environment.NewLine, buffer), entryParsers));
            entires.Reverse();

            return entires;
        }

        private T Parse<T>(string str, IEntryParser<T>[] parsers) where T : LogEntry
        {
            T entry = null;
            foreach (var entryParser in parsers)
            {
                entry = entryParser.Parse(str);
                if (entry.IsParseError == false)
                    break;
            }
            return entry;
        }
    }
}
