using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.DS
{
    public class DsEntryStartChecker: IEntryStartChecker
    {
        public bool Check(string line)
        {
            if (line.Length < 23) return false;

            var date = line.Substring(0, 23).Replace(',', '.');
            DateTime time;
            return DateTime.TryParse(date, out time);
        }
    }
}
