using System.Threading.Tasks;
using Soti.Comm.Protocol;
using Soti.MobiControl.DataTypes.Messages;

namespace Soti.CommTracer
{
    public class Client:IClient
    {
        private readonly CommClient _client;

        static Client()
        {
            MessageFactory.Register(typeof(CommPulseMsg), true);
            MessageFactory.Register(typeof(AckErrorMsg), true);
            MessageFactory.Register(typeof(ContentInfoMsg), true);
            MessageFactory.Register(typeof(DeviceConfigMsg), true);
            MessageFactory.Register(typeof(DeviceInfoMsg), true);
            MessageFactory.Register(typeof(DeviceNotifyMsg), true);
            MessageFactory.Register(typeof(DeviceScriptMsg), true);
            MessageFactory.Register(typeof(DeviceStatusMsg), true);
            MessageFactory.Register(typeof(FileBlockMsg), true);
            MessageFactory.Register(typeof(FileInfoMsg), true);
            MessageFactory.Register(typeof(InstallStatusMsg), true);
            MessageFactory.Register(typeof(DeltaPackageListMsg), true);
            MessageFactory.Register(typeof(LbsMsg), true);
            MessageFactory.Register(typeof(DirectoryInfoMsg), true);
            MessageFactory.Register(typeof(BinaryDataMsg), true);
            MessageFactory.Register(typeof(DeviceAdminMsg), true);
            MessageFactory.Register(typeof(AlertMsg), true);
            MessageFactory.Register(typeof(ClientInfoMsg), true);
            MessageFactory.Register(typeof(CommNotifyMsg), true);
            MessageFactory.Register(typeof(DeviceAdminMsg), true);
            MessageFactory.Register(typeof(DeviceRegistrationMsg), true);
            MessageFactory.Register(typeof(DeviceUnenrollMsg), true);
            MessageFactory.Register(typeof(DirectoryRequestMsg), true);
            MessageFactory.Register(typeof(ExchangeFileMsg), true);
            MessageFactory.Register(typeof(PingServerMsg), true);
            MessageFactory.Register(typeof(PrepareForRemoteControlMsg), true);
            MessageFactory.Register(typeof(RemoteControlLogMsg), true);
            MessageFactory.Register(typeof(RuleChangedNotifyMsg), true);
            MessageFactory.Register(typeof(SendMessageToDevicesMsg), true);
            MessageFactory.Register(typeof(SendScriptToDeviceMsg), true);
            MessageFactory.Register(typeof(ServerAdminMsg), true);
            MessageFactory.Register(typeof(CommDebugMsg), true);
        }

        public Client()
        {
            _client = new CommClient()
            {
                Configuration =
                {
                    Ssl = false,
                    CheckCertificateRevocation = false,
                    RequireClientCertificate = false
                }
            };

            _client.Configuration.Protocol = new ProtocolHandler(_client, (m) =>
            {
                OnMessageRecived?.Invoke(m);
            });
        }

        public void Dispose()
        {
            _client?.Disconnect();
        }

        public async Task<bool> Connect(string host, int port)
        {
            return await _client.ConnectAsync(host, port);
        }

        public void Disconnect()
        {
            _client?.Disconnect();
        }

        public event OnMessageRecived OnMessageRecived;
    }
}
