namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class KeyCheckResponse : Packet
    {
        public KeyCheckResponse(ulong summonerId, int clientId)
            : base(PacketCmd.KeyCheck)
        {
            Write((byte)0x2A);
            Write((byte)0);
            Write((byte)0xFF);
            Write((uint)clientId);
            Write((ulong)summonerId);
            Write((uint)0);
            Write((long)0);
            Write((uint)0);
        }
    }
}