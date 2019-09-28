using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class MissileReplication : BasePacket
    {
        private readonly Vector3 _position;
        private readonly Vector3 _casterPosition;
        private readonly Vector3 _direction;
        private readonly Vector3 _velocity;
        private readonly Vector3 _startPoint;
        private readonly Vector3 _endPoint;
        private readonly Vector3 _unitPosition;
        private readonly float _timeFromCreation;
        private readonly float _speed;
        private readonly float _lifePercentage;
        private readonly float _timedSpeedDelta;
        private readonly float _timedSpeedDeltaTime;

        // TODO: verify bitfield
        private readonly bool _bounced;

        private readonly CastInfo _castInfo;

        public MissileReplication(uint projectileNetId, Vector3 position, Vector3 casterPosition, Vector3 direction, Vector3 velocity, Vector3 startPoint, Vector3 endPoint, Vector3 unitPosition, float timeFromCreation, float speed, float lifePercentage, float timedSpeedDelta, float timedSpeedDeltaTime, bool bounced, CastInfo castInfo)
            : base(PacketCmd.S2CMissileReplication, projectileNetId)
        {
            _position = position;
            _casterPosition = casterPosition;
            _direction = direction;
            _velocity = velocity;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _unitPosition = unitPosition;
            _timeFromCreation = timeFromCreation;
            _speed = speed;
            _lifePercentage = lifePercentage;
            _timedSpeedDelta = timedSpeedDelta;
            _timedSpeedDeltaTime = timedSpeedDeltaTime;
            _bounced = bounced;
            _castInfo = castInfo;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteVector3(_position);
            WriteVector3(_casterPosition);
            WriteVector3(_direction);
            WriteVector3(_velocity);
            WriteVector3(_startPoint);
            WriteVector3(_endPoint);
            WriteVector3(_unitPosition);
            WriteFloat(_timeFromCreation);
            WriteFloat(_speed);
            WriteFloat(_lifePercentage);
            WriteFloat(_timedSpeedDelta);
            WriteFloat(_timedSpeedDeltaTime);

            byte bitfield = 0;
            if (_bounced)
            {
                bitfield |= 1;
            }
            WriteByte(bitfield);

            GetWriter().WriteCastInfo(_castInfo);
        }
    }
}