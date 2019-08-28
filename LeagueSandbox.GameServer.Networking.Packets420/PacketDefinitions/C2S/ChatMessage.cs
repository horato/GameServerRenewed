using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.ChatBoxMessage, Channel.Communication)]
	internal class ChatMessage : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int PlayerId { get; }
		public int BotNetId { get; }
		public byte IsBotMessage { get; }

		public ChatType Type { get; }
		public int Unk1 { get; } // playerNo?
		public int Length { get; }
		public byte[] Unk2 { get; }
		public string Msg { get; }

		public ChatMessage(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                PlayerId = reader.ReadInt32();
                BotNetId = reader.ReadInt32();
                IsBotMessage = reader.ReadByte();
                Type = (ChatType)reader.ReadInt32();
                Unk1 = reader.ReadInt32();
                Length = reader.ReadInt32();
                Unk2 = reader.ReadBytes(32);

                var bytes = new List<byte>();
                for (var i = 0; i < Length; i++)
                {
                    bytes.Add(reader.ReadByte());
                }

                Msg = Encoding.Default.GetString(bytes.ToArray());
            }
        }
    }
}