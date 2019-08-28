using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class RenameResponse : Packet
    {
        public RenameResponse(ulong summonerId, int skinId, string playerName) : base(PacketCmd.S2CRenameResponse)
        {
            WriteULong(summonerId);
            WriteInt(skinId);

            var nameBytes = Encoding.UTF8.GetBytes(playerName);
            WriteInt(nameBytes.Length + 1);
            WriteBytes(nameBytes);
            WriteByte(0);
        }
    }
}