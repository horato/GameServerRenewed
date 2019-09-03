using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing.DTOs;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class IssueOrderRequest : RequestDefinition
    {
        public MovementType OrderType { get; }
        public Vector2 Position { get; }
        public uint TargetNetID { get; }
        public MovementData MovementData { get; }

        public IssueOrderRequest(MovementType orderType, Vector2 position, uint targetNetId, MovementData movementData)
        {
            OrderType = orderType;
            Position = position;
            TargetNetID = targetNetId;
            MovementData = movementData;
        }
    }
}
