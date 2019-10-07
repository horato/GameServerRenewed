using System.IO;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class ChatRequest : RequestDefinition
    {
        public int ClientID { get; }
        public uint NetID { get; }
        public bool Localized { get; }
        public ChatType ChatType { get; }
        public string Params { get; }
        public string Message { get; }

        public ChatRequest(int clientId, uint netId, bool localized, ChatType chatType, string @params, string message)
        {
            ClientID = clientId;
            NetID = netId;
            Localized = localized;
            ChatType = chatType;
            Params = @params;
            Message = message;
        }
    }
}