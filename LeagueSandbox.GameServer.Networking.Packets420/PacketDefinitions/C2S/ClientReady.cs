using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SClientReady)]
    internal class ClientReady : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint NetId { get; }
        public TipConfig TipConfig { get; }

        public ClientReady(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                reader.ReadInt32();
                TipConfig = ReadTipConfig(reader);
                reader.ReadInt64();
            }
        }

        private TipConfig ReadTipConfig(BinaryReader reader)
        {
            var tipID = reader.ReadSByte();
            var colorID = reader.ReadSByte();
            var durationID = reader.ReadSByte();
            var flags = reader.ReadSByte();

            return new TipConfig(tipID, colorID, durationID, flags);
        }
    }
}
