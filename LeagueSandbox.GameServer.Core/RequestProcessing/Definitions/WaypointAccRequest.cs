using System.IO;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class WaypointAccRequest : RequestDefinition
    {
        public uint NetId { get; }
        public int SyncID { get; }
        public byte TeleportCount { get; }

        public WaypointAccRequest(uint netId, int syncId, byte teleportCount)
        {
            NetId = netId;
            SyncID = syncId;
            TeleportCount = teleportCount;
        }
    }
}
