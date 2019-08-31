using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class WorldSendCameraRequest : RequestDefinition
    {
        public int NetId { get; }
        public Vector3 CameraPosition { get; }
        public Vector3 CameraDirection { get; }
        public int ClientID { get; }
        public byte SyncID { get; }

        public WorldSendCameraRequest(int netId, Vector3 cameraPosition, Vector3 cameraDirection, int clientId, byte syncId)
        {
            NetId = netId;
            CameraPosition = cameraPosition;
            CameraDirection = cameraDirection;
            ClientID = clientId;
            SyncID = syncId;
        }
    }
}
