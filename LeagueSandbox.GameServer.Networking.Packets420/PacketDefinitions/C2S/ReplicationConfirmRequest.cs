using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.OnReplicationConfirm)]
    internal class ReplicationConfirmRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint NetId { get; }
        public uint SyncID { get; }

        public ReplicationConfirmRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                SyncID = reader.ReadUInt32();
            }
        }
    }
}
