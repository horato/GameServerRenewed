using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class ReskinResponse : Packet
    {
        public ReskinResponse(ulong summonerId, int skinId, string skinName) : base(PacketCmd.S2CReskinResponse)
        {
            WriteULong(summonerId);
            WriteInt(skinId);

            var skinNameBytes = Encoding.UTF8.GetBytes(skinName);
            WriteInt(skinNameBytes.Length + 1);
            WriteBytes(skinNameBytes);
            WriteByte(0);
        }
    }
}