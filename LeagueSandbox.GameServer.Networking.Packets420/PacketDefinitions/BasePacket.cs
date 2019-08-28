namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions
{
	internal abstract class BasePacket : Packet
    {
        protected BasePacket(PacketCmd cmd, uint netId = 0) : base(cmd)
        {
            WriteUInt(netId);
            if ((short)cmd > 0xFF) // Make an extended packet instead
            {
                Bytes[0] = (byte)PacketCmd.S2CExtended;
                WriteShort((short)cmd);
            }
        }
    }
}