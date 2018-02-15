using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.McInstall
{
    public class McInstallEntryStartChecker: IEntryStartChecker
    {
        public bool Check(string line)
        {
            if (line.Length < 18)
                return false;

            return DateTime.TryParse(line.Substring(0, line.IndexOf(' ')), out var date);
        }
    }
}
