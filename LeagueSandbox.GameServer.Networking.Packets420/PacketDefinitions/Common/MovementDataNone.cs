using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class MovementDataNone : MovementData
    {
        public override MovementDataType Type => MovementDataType.None;

        public MovementDataNone() : base(0)
        {
        }

        public override byte[] GetData()
        {
            return new byte[0];
        }
    }
}