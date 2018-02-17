using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.CloudLink
{
    public class ClaEntryStartChecker: IEntryStartChecker
    {
        public bool Check(string line)
        {
            return line[0] == '[' && DateTime.TryParse(line.Substring(1, 10), out var _);
        }
    }
}
