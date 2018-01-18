using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Soti.LogReader.Common
{
    public interface ILogFileReader
    {
        Task<IEnumerable<string>> Read(FileInfo fileInfo);
    }
}
