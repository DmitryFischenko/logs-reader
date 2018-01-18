using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Soti.LogReader.Common
{
    public class LogFileReader : ILogFileReader
    {
        private long _position = 0;

        private FileInfo _fileInfo;

        public async Task<IEnumerable<string>> Read(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;

            string text;
            using (var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream))
                {
                    text = await reader.ReadToEndAsync();
                    _position = stream.Position;
                }
            }
            return text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }

        public async Task<IEnumerable<string>> Read()
        {
            string text;
            using (var stream = new FileStream(_fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                stream.Seek(_position, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                {
                    text = await reader.ReadToEndAsync();
                    _position = stream.Position;
                }
            }
            return text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
