using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    /// <summary> Used for Obj_Ai_Turret </summary>
    internal class CreateTurret : BasePacket
    {
        private readonly uint _netId;
        private readonly NetNodeID _netNodeId;
        private readonly string _name;
        private readonly bool _isTargetable;
        private readonly SpellFlags _isTargetableToTeam;

        public CreateTurret(uint netId, NetNodeID netNodeId, string name, bool isTargetable, SpellFlags isTargetableToTeam) : base(PacketCmd.S2CCreateTurret, netId)
        {
            _netId = netId;
            _netNodeId = netNodeId;
            _name = name;
            _isTargetable = isTargetable;
            _isTargetableToTeam = isTargetableToTeam;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteUInt(_netId);
            WriteByte((byte)_netNodeId);
            WriteFixedString(_name, 64);

            byte bitfield = 0;
            if (_isTargetable)
                bitfield |= 1;
            WriteByte(bitfield);

            WriteUInt((uint)_isTargetableToTeam);
        }
    }
}