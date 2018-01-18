using Soti.LogReader.Common;
using System;

namespace Soti.LogReader.Components.DbInstall.Filters
{
    public class DacPackOnlyFilter : IFilter<DbInstallLogEntry>
    {
        public string Title { get => "DacPack entries"; }
        public Predicate<DbInstallLogEntry> Func { get => (e) => e.IsDacpack == true; }
    }
}
