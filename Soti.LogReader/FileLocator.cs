using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Soti.LogReader.Configuration;

namespace Soti.LogReader
{
    public class FileLocator
    {
        public IEnumerable<FileInfo> Locate(FileLocateConfig config)
        {
            if (!config.Directories.Any())
                throw new ArgumentException("No directory specified");

            if (!config.FileMasks.Any())
                throw new ArgumentException("No file masks specifed");

            foreach (var configDirectory in config.Directories)
            {
                foreach (var file in Directory.EnumerateFiles(configDirectory))
                {
                    if(DoesFileMatch(file, config.FileMasks))
                        yield return new FileInfo(file);
                }
            }
        }

        private bool DoesFileMatch(string fileName, IEnumerable<string> masks)
        {
            foreach (var mask in masks)
            {
                if (Regex.IsMatch(fileName, mask))
                    return true;
            }

            return false;
        }
    }
}
