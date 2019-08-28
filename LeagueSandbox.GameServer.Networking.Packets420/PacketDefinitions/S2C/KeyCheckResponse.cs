namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class KeyCheckResponse : Packet
    {
        public KeyCheckResponse(ulong summonerId, int clientId)
            : base(PacketCmd.KeyCheck)
        {
            WriteByte(0x2A);
            WriteByte(0);
            WriteByte(0xFF);
            WriteUInt((uint)clientId);
            WriteULong(summonerId);
            WriteUInt(0);
            WriteLong(0);
            WriteUInt(0);
        }
    }
}