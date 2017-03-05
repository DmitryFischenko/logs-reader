using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Parsers;

namespace Soti.LogReader
{
    public class LogFileReader : ILogFileReader
    {
        public async Task<IEnumerable<string>> Read(FileInfo fileInfo)
        {
            string text;
            using (var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream))
                {
                    text = await reader.ReadToEndAsync();
                }
            }
            return text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }
    }
}
