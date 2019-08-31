namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SyncMissionStartTime : BasePacket
    {
        public SyncMissionStartTime(float startTime) : base(PacketCmd.S2CSyncMissionStartTime)
        {
            WriteFloat(startTime);
        }
    }
}