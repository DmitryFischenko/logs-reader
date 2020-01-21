using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soti.Comm;
using Soti.Comm.Protocol;
using Soti.CommTracer.Model;
using Soti.MobiControl.DataTypes.Messages;

namespace Soti.CommTracer
{
    class ProtocolHandler:IProtocolHandler
    {
        private CommClient _commClient;
        private readonly Action<CommMessage> _onProcess;

        public ProtocolHandler(CommClient client, Action<CommMessage> onProcess)
        {
            _commClient = client;
            _onProcess = onProcess;
        }

        public void OnConnected(IConnection connection)
        {
            var msg = new CommDebugMsg
            {
                Flags = CommDebugMsg.DebugFlags.Inbound | CommDebugMsg.DebugFlags.Outbound,
                Command = CommDebugMsg.DebugCommand.On
            };
            _commClient.SendNotify(msg);
        }

        public void OnClosed(IConnection connection)
        {
        }

        public bool Process(IConnection connection, Stream stream)
        {
            try
            {
                var msg = MessageFactory.Deserialize(stream);
                if (msg is CommPulseMsg)
                {
                    _commClient.Send(new CommPulseMsg());
                    return true;
                }

                if (msg is CommDebugMsg commMsg)
                {
                    if (!string.IsNullOrEmpty(commMsg.Message))
                        _onProcess?.Invoke(Parse(commMsg));
                }
            }
            catch (Exception ex)
            {
                
            }

            return true;
        }

        private CommMessage Parse(CommDebugMsg commMsg)
        {
            var message = commMsg.Message.Substring(0, commMsg.Message.LastIndexOf(','));
            //var parts = message.Split(',');

           //message = string.Join(",", parts.Take(parts.Length - 1).Where(p => !p.EndsWith("{}")));

            var type = message.Substring(0, message.IndexOf(':'));

            return new CommMessage()
            {
                MessageType = type,
                Message = message,
                TimeStamp = commMsg.TimeStamp
            };
        }
    }
}
