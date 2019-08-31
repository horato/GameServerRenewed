using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class AddRegion : BasePacket
    {
        private readonly TeamId _teamId;
        private readonly int _regionType;
        private readonly int _clientId;
        private readonly uint _unitNetId;
        private readonly uint _bubbleNetId;
        private readonly uint _visionTargetNetId;
        private readonly Vector2 _position;
        private readonly float _timeToLive;
        private readonly float _colisionRadius;
        private readonly float _grassRadius;
        private readonly float _sizeMultiplier;
        private readonly float _sizeAdditive;
        private readonly bool _hasCollision;
        private readonly bool _grantVision;
        private readonly bool _revealStealth;
        private readonly float _baseRadius;

        public AddRegion(TeamId teamId, int regionType, int clientId, uint unitNetId, uint bubbleNetId, uint visionTargetNetId, Vector2 position, float timeToLive, float colisionRadius, float grassRadius, float sizeMultiplier, float sizeAdditive, bool hasCollision, bool grantVision, bool revealStealth, float baseRadius) : base(PacketCmd.S2CAddRegion)
        {
            _teamId = teamId;
            _regionType = regionType;
            _clientId = clientId;
            _unitNetId = unitNetId;
            _bubbleNetId = bubbleNetId;
            _visionTargetNetId = visionTargetNetId;
            _position = position;
            _timeToLive = timeToLive;
            _colisionRadius = colisionRadius;
            _grassRadius = grassRadius;
            _sizeMultiplier = sizeMultiplier;
            _sizeAdditive = sizeAdditive;
            _hasCollision = hasCollision;
            _grantVision = grantVision;
            _revealStealth = revealStealth;
            _baseRadius = baseRadius;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteUInt((uint)_teamId);
            WriteInt(_regionType);
            WriteInt(_clientId);
            WriteUInt(_unitNetId);
            WriteUInt(_bubbleNetId);
            WriteUInt(_visionTargetNetId);
            WriteFloat(_position.X);
            WriteFloat(_position.Y);
            WriteFloat(_timeToLive);
            WriteFloat(_colisionRadius);
            WriteFloat(_grassRadius);
            WriteFloat(_sizeMultiplier);
            WriteFloat(_sizeAdditive);

            byte flags = 0;
            if (_hasCollision)
                flags |= 1;
            if (_grantVision)
                flags |= 2;
            if (_revealStealth)
                flags |= 4;

            WriteByte(flags);
            WriteFloat(_baseRadius);
        }
    }
}