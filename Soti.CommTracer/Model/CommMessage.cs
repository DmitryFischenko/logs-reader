
using System;

namespace Soti.CommTracer.Model
{
    public class CommMessage
    {
        public string Message { get; set; }
        public string MessageType { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
