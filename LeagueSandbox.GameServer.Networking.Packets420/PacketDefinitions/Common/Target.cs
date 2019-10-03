using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    public class Target
    {
        public uint UnitNetID { get; }
        public HitResult HitResult { get; }

        public Target(uint unitNetId, HitResult hitResult)
        {
            UnitNetID = unitNetId;
            HitResult = hitResult;
        }
    }
}