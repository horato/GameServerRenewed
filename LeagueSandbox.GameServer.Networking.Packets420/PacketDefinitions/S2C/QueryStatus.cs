namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class QueryStatus : BasePacket
    {
        public QueryStatus() : base(PacketCmd.S2CQueryStatusAns)
        {
            Write((byte)1); //ok
        }
    }
}