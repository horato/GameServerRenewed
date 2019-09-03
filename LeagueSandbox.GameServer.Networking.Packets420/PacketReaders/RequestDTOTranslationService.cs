using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using CompressedWaypoint = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.CompressedWaypoint;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
    internal class RequestDTOTranslationService : IRequestDTOTranslationService
    {
        public MovementData TranslateMovementData(MovementDataNormal movementData)
        {
            if (movementData == null)
                return null; // Not throw; null is valid business case

            return new MovementData
            (
                movementData.TeleportNetID,
                movementData.HasTeleportID,
                movementData.TeleportID,
                movementData.SyncID,
                TranslateWaypoints(movementData.Waypoints).ToList()
            );
        }

        private IEnumerable<CompressedWaypoint> TranslateWaypoints(IList<PacketDefinitions.Common.CompressedWaypoint> waypoints)
        {
            var idx = 0;
            return waypoints.Select(x => new CompressedWaypoint(idx++, new Vector2(x.X, x.Y))).ToList();
        }
    }
}
