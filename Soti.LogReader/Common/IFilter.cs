using Soti.LogReader.Entries;
using System;

namespace Soti.LogReader.Common
{
    public interface IFilter<T> where T : LogEntry
    {
        string Title { get; }
        Predicate<T> Func { get; }
    }
}
