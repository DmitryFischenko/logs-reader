using System;
using System.Net;
using System.Threading.Tasks;
using Soti.CommTracer.Model;

namespace Soti.CommTracer
{
    public delegate void OnMessageRecived(CommMessage message);

    public interface IClient:IDisposable
    {
        Task<bool> Connect(string host, int port);
        void Disconnect();

        event OnMessageRecived OnMessageRecived;
    }
}
