using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class UnitSetLookAt : BasePacket
    {
        public UnitSetLookAt(uint sourceNetId, LookAtType lookAtType, Vector3 targetPosition, uint targetNetId) : base(PacketCmd.S2CUnitSetLookAt, sourceNetId)
        {
            WriteByte((byte)lookAtType);
            WriteVector3(targetPosition);
            WriteUInt(targetNetId);
        }
    }
}