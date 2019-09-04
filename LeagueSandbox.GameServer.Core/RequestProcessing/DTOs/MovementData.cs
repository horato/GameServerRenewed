using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.DTOs
{
    public class MovementData
    {
        public uint TeleportNetID { get; }
        public bool HasTeleportID { get; }
        public byte TeleportID { get; }
        public uint SyncID { get; }
        public IEnumerable<CompressedWaypoint> Waypoints { get; set; }

        public MovementData(uint teleportNetId, bool hasTeleportId, byte teleportId, uint syncId, IEnumerable<CompressedWaypoint> waypoints)
        {
            TeleportNetID = teleportNetId;
            HasTeleportID = hasTeleportId;
            TeleportID = teleportId;
            SyncID = syncId;
            Waypoints = waypoints;
        }
    }
}
