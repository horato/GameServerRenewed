using System.IO;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class ChatResponse : Packet
    {
        public int ClientID { get; }
        public uint NetID { get; }
        public bool Localized { get; }
        public ChatType ChatType { get; }
        public string Params { get; }
        public string Message { get; }

        public ChatResponse(int clientId, uint netId, bool localized, ChatType chatType, string @params, string message)
            : base(PacketCmd.Chat)
        {
            ClientID = clientId;
            NetID = netId;
            Localized = localized;
            ChatType = chatType;
            Params = @params;
            Message = message;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteInt(ClientID);
            WriteUInt(NetID);
            WriteBool(Localized);
            WriteUInt((uint)ChatType);

            byte[] pars;
            byte[] message;
            if (Localized)
            {
                pars = Encoding.UTF8.GetBytes(Params);
                message = Encoding.UTF8.GetBytes(Message);
            }
            else
            {
                pars = Encoding.ASCII.GetBytes(Params);
                message = Encoding.ASCII.GetBytes(Message);
            }

            var paramsSize = pars.Length;
            if (paramsSize > 32)
                throw new IOException("Params size too big");

            var messageSize = message.Length;
            if (messageSize > 1024)
                throw new IOException("Message size too big");

            WriteInt(paramsSize);
            WriteInt(messageSize);
            WriteBytes(pars);

            if (paramsSize < 32)
                WriteZero(32 - paramsSize);

            WriteBytes(message);
            WriteZero(1);
        }
    }
}