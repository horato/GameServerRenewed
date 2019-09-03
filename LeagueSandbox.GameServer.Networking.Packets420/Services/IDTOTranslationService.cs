using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal interface IDTOTranslationService
    {
        PlayerLoadInfo TranslatePlayerLoadInfo(IPlayer player);
        MovementData TranslateMovementData(MovementDataNormal movementData);
        IEnumerable<MovementDataNormal> TranslateMovementUpdate(IEnumerable<IGameObject> gameObjects, int syncId, Vector2 mapCenter);
    }
}