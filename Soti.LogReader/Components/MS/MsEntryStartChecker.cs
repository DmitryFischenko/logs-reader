using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.MS
{
    public class MsEntryStartChecker: IEntryStartChecker
    {
        public bool Check(string line)
        {
            if (line.Length < 37)
                return false;
            var dateStr = line.Substring(1, 10);

            return DateTime.TryParse(dateStr, out var _) || DateTime.TryParse(line.Substring(4, 10), out _);
        }
    }
}
