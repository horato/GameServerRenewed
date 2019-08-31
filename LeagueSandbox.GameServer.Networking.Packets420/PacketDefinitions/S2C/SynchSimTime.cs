namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SynchSimTime : BasePacket
    {
        public SynchSimTime(float syncTime) : base(PacketCmd.S2CSynchSimTime)
        {
            WriteFloat(syncTime);
        }
    }
}