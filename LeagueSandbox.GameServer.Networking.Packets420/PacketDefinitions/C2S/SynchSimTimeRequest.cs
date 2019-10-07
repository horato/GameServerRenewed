using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SSynchSimTime, Channel.SynchClock)]
    internal class SynchSimTimeRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint SenderNetId { get; }
        public float TimeLastServerSeconds { get; }
        public float TimeLastClientSeconds { get; }

        public SynchSimTimeRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                SenderNetId = reader.ReadUInt32();
                TimeLastServerSeconds = reader.ReadSingle();
                TimeLastClientSeconds = reader.ReadSingle();
            }
        }
    }
}
