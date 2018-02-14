using Prism.Events;

namespace Soti.LogReader.Viewer
{
    internal static class EventBus
    {
        public static IEventAggregator Bus { get; } = new EventAggregator();
    }
}