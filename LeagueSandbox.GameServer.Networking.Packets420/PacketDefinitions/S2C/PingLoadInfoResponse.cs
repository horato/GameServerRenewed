namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class PingLoadInfoResponse : BasePacket
    {
        public PingLoadInfoResponse(uint netId, int clientId, ulong summonerId, float loadedPercent, float eta, ushort count, ushort ping, bool isReady)
            : base(PacketCmd.S2CPingLoadInfo, netId)
        {
            WriteInt(clientId);
            WriteULong(summonerId);
            WriteFloat(loadedPercent);
            WriteFloat(eta);
            WriteUShort(count);
            WriteUShort(ping);

            byte bitfield = 0;
            if (isReady)
                bitfield |= 0x01;
            WriteByte(bitfield);
        }
    }
}