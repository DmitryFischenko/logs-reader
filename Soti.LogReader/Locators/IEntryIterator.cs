using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Locators
{
    public interface IEntryIterator<T> where T : class
    {
        void SetList(T[] list);
        T Current { get; }
        void Next();
        void Previous();
        void Last();
        void Reset();
    }
}
