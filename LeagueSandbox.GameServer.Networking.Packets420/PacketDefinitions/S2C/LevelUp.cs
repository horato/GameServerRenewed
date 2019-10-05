namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class LevelUp : BasePacket
    {
        public LevelUp(uint netId, byte level, byte availablePoints) : base(PacketCmd.S2CLevelUp, netId)
        {
            WriteByte(level);
            WriteByte(availablePoints);
        }
    }
}