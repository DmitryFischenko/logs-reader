using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Soti.LogReader.Entries;
using Soti.LogReader.Parsers;

namespace Soti.LogReader
{
    public interface ILogFileReader
    {
        Task<IEnumerable<string>> Read(FileInfo fileInfo);
    }
}
