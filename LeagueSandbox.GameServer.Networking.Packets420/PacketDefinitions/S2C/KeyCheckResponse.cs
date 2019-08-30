namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class KeyCheckResponse : Packet
    {
        public KeyCheckResponse(ulong summonerId, int clientId, uint versionNo, ulong checkId) : base(PacketCmd.KeyCheck)
        {
            WriteByte(0x2A);
            WriteByte(0);
            WriteByte(0xFF);
            WriteInt(clientId);
            WriteULong(summonerId);
            WriteUInt(versionNo);
            WriteULong(checkId);
            WriteUInt(0);
        }
    }
}