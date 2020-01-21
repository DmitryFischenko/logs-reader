using System.IO;
using Prism.Events;
using Soti.CommTracer.Model;
using Soti.LogReader.Entries;
using Soti.LogReader.Log;
using Soti.LogReader.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer
{
    class OpenLogFile : PubSubEvent<LogFile> { };
    class ActivateView : PubSubEvent<DockContent> { };
    class AddView : PubSubEvent<DockContent> { };
    class ViewRemoved : PubSubEvent<IDockContent> { };
    class LogEntrySelected : PubSubEvent<LogEntry> { };

    class CommTracerMessageSelected : PubSubEvent<CommMessage>{ };

    class AddFile : PubSubEvent<string> { };

    class FilterByText : PubSubEvent<string>
    {
    };
}
