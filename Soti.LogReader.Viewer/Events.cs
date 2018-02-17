using System.IO;
using Prism.Events;
using Soti.LogReader.Entries;
using Soti.LogReader.Log;
using Soti.LogReader.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer
{
    class LogFileDoubleClick : PubSubEvent<LogFile> { };
    class ActivateView : PubSubEvent<DockContent> { };
    class AddView : PubSubEvent<DockContent> { };
    class ViewRemoved : PubSubEvent<IDockContent> { };
    class LogEntrySelected : PubSubEvent<LogEntry> { };

    class AddFile : PubSubEvent<string> { };

    class FilterByText : PubSubEvent<string>
    {
    };
}
