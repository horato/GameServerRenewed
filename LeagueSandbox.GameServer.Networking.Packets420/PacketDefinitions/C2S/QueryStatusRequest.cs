using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SQueryStatusReq)]
    internal class QueryStatusRequest : IRequestPacketDefinition
    {
        public QueryStatusRequest(byte[] data)
        {

        }
    }
}
