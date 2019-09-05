using System;
using System.Collections.Generic;
using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class MovementDataWithSpeed : MovementDataNormal
    {
        public override MovementDataType Type => MovementDataType.WithSpeed;
        public SpeedParams SpeedParams { get; set; }

        public MovementDataWithSpeed(uint syncId, uint unitNetId, bool hasTeleportId, byte teleportId, IList<CompressedWaypoint> waypoints, SpeedParams speedParams) : base(syncId, unitNetId, hasTeleportId, teleportId, waypoints)
        {
            SpeedParams = speedParams;
        }

        public override byte[] GetData()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                var waypointsSize = Waypoints.Count;
                if (waypointsSize > 0x7F)
                    throw new InvalidOperationException("Too many paths > 0x7F!");

                byte bitfield = 0;
                if (Waypoints != null)
                    bitfield |= (byte)(waypointsSize << 1);
                if (HasTeleportID)
                    bitfield |= 1;

                writer.Write((byte)bitfield);
                if (Waypoints != null)
                {
                    writer.Write((uint)UnitNetId);
                    if (HasTeleportID)
                        writer.Write((byte)TeleportID);

                    writer.WriteWaypointSpeedParams(SpeedParams);
                    writer.WriteCompressedWaypoints(Waypoints);
                }

                return stream.ToArray();
            }
        }
    }
}