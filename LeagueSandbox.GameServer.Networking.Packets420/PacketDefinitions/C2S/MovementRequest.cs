using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SIssueOrderRequest)]
    internal class IssueOrderRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint NetId { get; }
        public MovementType OrderType { get; }
        public Vector2 Position { get; }
        public uint TargetNetID { get; }
        public MovementDataNormal MovementData { get; }

        public IssueOrderRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                OrderType = (MovementType)reader.ReadByte();
                Position = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                TargetNetID = reader.ReadUInt32();

                if (reader.BaseStream.Length - reader.BaseStream.Position > 4)
                    MovementData = ReadMovementData(reader);
            }
        }

        private MovementDataNormal ReadMovementData(BinaryReader reader)
        {
            var bitfield = reader.ReadByte();
            var size = (byte)(bitfield >> 1);
            if (size <= 0)
                return null;

            var hasTeleportID = (bitfield & 1) != 0;
            var teleportNetID = reader.ReadUInt32();
            byte teleportID = 0;
            if (hasTeleportID)
            {
                teleportID = reader.ReadByte();
            }

            var waypoints = reader.ReadCompressedWaypoints(size);
            return new MovementDataNormal(0, teleportNetID, hasTeleportID, teleportID, waypoints);
        }
    }
}