using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.LogReader.Entries;

namespace Soti.LogReader.Locators
{
    public class EntryIterator<T> : IEntryIterator<T> where T:class
    {
        private T[] _list;
        private int _index = 0;

        public void SetList(T[] list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            _list = list;

            Reset();
        }

        public T Current => _index == -1 ? null : _list[_index];

        public void Next()
        {
            if (_index == _list.Length - 1)
                return;
            _index++;
        }

        public void Previous()
        {
            if (_index <= 0)
                return;
            _index--;
        }

        public void Last()
        {
            _index = _list.Length - 1;
        }

        public void Reset()
        {
            _index = _list.Any() ? 0 : -1;
        }

        public void SetCurrent(T entry)
        {
            _index = Array.IndexOf(_list, entry);
        }
    }
}
