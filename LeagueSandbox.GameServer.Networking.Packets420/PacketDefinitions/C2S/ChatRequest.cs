using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.Chat, Channel.Chat)]
    internal class ChatRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public int ClientID { get; }
        public uint NetID { get; }
        public bool Localized { get; }
        public ChatType ChatType { get; }
        public string Params { get; }
        public string Message { get; }

        public ChatRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                ClientID = reader.ReadInt32();
                NetID = reader.ReadUInt32();
                Localized = reader.ReadBoolean();
                ChatType = (ChatType)reader.ReadUInt32();

                var paramsSize = reader.ReadInt32();
                if (paramsSize > 32)
                    throw new IOException("Params size too big");

                var messageSize = reader.ReadInt32();
                if (messageSize > 1024)
                    throw new IOException("Message size too big");

                var pars = reader.ReadBytes(32).Take(paramsSize).ToArray();
                var msg = reader.ReadBytes(messageSize);
                if (Localized)
                {
                    Params = Encoding.UTF8.GetString(pars);
                    Message = Encoding.UTF8.GetString(msg);
                    reader.ReadByte();
                }
                else
                {
                    Params = Encoding.ASCII.GetString(pars);
                    Message = Encoding.ASCII.GetString(msg);
                    reader.ReadByte();
                }
            }
        }
    }
}