using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SpawnLevelProp : BasePacket
    {
        private readonly uint _netId;
        private readonly NetNodeID _netNodeId;
        private readonly int _skinId;
        private readonly Vector3 _position;
        private readonly Vector3 _facingDirection;
        private readonly Vector3 _positionOffset;
        private readonly Vector3 _scale;
        private readonly TeamId _teamId;
        private readonly byte _skillLevel;
        private readonly byte _rank;
        private readonly LevelPropType _type;
        private readonly string _propName;
        private readonly string _skinName;

        public SpawnLevelProp(uint netId, NetNodeID netNodeId, int skinId, Vector3 position, Vector3 facingDirection, Vector3 positionOffset, Vector3 scale, TeamId teamId, byte skillLevel, byte rank, LevelPropType type, string propName, string skinName) : base(PacketCmd.S2CSpawnLevelProp)
        {
            _netId = netId;
            _netNodeId = netNodeId;
            _skinId = skinId;
            _position = position;
            _facingDirection = facingDirection;
            _positionOffset = positionOffset;
            _scale = scale;
            _teamId = teamId;
            _skillLevel = skillLevel;
            _rank = rank;
            _type = type;
            _propName = propName;
            _skinName = skinName;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteUInt(_netId);
            WriteByte((byte)_netNodeId);
            WriteInt(_skinId);
            WriteVector3(_position);
            WriteVector3(_facingDirection);
            WriteVector3(_positionOffset);
            WriteVector3(_scale);
            WriteShort((short)_teamId);
            WriteByte(_rank);
            WriteByte(_skillLevel);
            WriteUInt((byte)_type);
            WriteFixedString(_propName, 64);
            WriteFixedString(_skinName, 64);
        }
    }
}