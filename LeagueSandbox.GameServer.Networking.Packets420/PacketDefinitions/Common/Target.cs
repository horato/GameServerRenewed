namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    public class Target
    {
        public uint UnitNetID { get; }
        public byte HitResult { get; }

        public Target(uint unitNetId, byte hitResult)
        {
            UnitNetID = unitNetId;
            HitResult = hitResult;
        }
    }
}