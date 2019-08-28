using System.IO;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SRequestJoinTeam, Channel.LoadingScreen)]
    internal class JoinTeamRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public int ClientId { get; set; }
        public uint NetTeamId { get; set; }

        public JoinTeamRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                ClientId = reader.ReadInt32();
                NetTeamId = reader.ReadUInt32();
            }
        }
    }
}