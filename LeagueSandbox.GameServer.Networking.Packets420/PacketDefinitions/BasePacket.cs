namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions
{
    internal abstract class BasePacket : Packet
    {
        protected BasePacket(PacketCmd cmd, uint netId = 0) : base(cmd)
        {
            if (cmd > PacketCmd.S2CBatch) // Make an extended packet instead
            {
                Clear();
                WriteByte((byte)PacketCmd.S2CExtended);
            }

            WriteUInt(netId);

            if (cmd > PacketCmd.S2CBatch)
                WriteShort((short)cmd);
        }
    }
}