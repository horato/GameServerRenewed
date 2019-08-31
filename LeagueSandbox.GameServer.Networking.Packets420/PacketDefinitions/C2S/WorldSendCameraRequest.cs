using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SWorldSendCamera)]
    internal class WorldSendCameraRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public int NetId { get; }
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public int ClientID { get; set; }
        public byte SyncID { get; set; }

        public WorldSendCameraRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadInt32();
                CameraPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                CameraDirection = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                ClientID = reader.ReadInt32();
                SyncID = reader.ReadByte();
            }
        }
    }
}