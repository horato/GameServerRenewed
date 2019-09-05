using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class WaypointGroup : BasePacket
    {
        private readonly uint _syncId;
        private readonly IList<MovementDataNormal> _movements;

        public WaypointGroup(uint syncId, IEnumerable<MovementDataNormal> movements) : base(PacketCmd.S2CWaypointGroup)
        {
            _syncId = syncId;
            _movements = movements?.ToList() ?? new List<MovementDataNormal>();

            WritePacket();
        }

        private void WritePacket()
        {
            var count = _movements.Count;
            if (count > 0x7FFF)
                throw new InvalidOperationException("Too many movements");

            WriteUInt(_syncId);
            WriteUShort((ushort)count);
            foreach (var data in _movements)
            {
                WriteMovementData(data);
            }
        }

        private void WriteMovementData(MovementDataNormal data)
        {
            var waypointsSize = data.Waypoints.Count;
            if (waypointsSize > 0x7F)
                throw new InvalidOperationException("Too many waypoints");

            byte bitfield = 0;
            if (data.Waypoints != null)
            {
                bitfield |= (byte)(waypointsSize << 1);
            }
            if (data.HasTeleportID)
            {
                bitfield |= 1;
            }

            WriteByte(bitfield);

            if (data.Waypoints != null)
            {
                WriteUInt(data.UnitNetId);
                if (data.HasTeleportID)
                    WriteByte(data.TeleportID);

                GetWriter().WriteCompressedWaypoints(data.Waypoints);
            }
        }
    }
}