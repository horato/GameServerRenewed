using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SWaypointAcc)]
    internal class WaypointAccRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint NetId { get; }
        public int SyncID { get; }
        public byte TeleportCount { get; }

        public WaypointAccRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                SyncID = reader.ReadInt32();
                TeleportCount = reader.ReadByte();
            }
        }
    }
}
