using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal interface IDTOTranslationService
    {
        PlayerLoadInfo TranslatePlayerLoadInfo(IPlayer player);
        MovementData TranslateMovementData(MovementDataNormal movementData);
        IEnumerable<MovementDataNormal> TranslateMovementUpdate(IEnumerable<IGameObject> gameObjects, uint syncId, Vector2 mapCenter);
        IEnumerable<ReplicationData> TranslateReplicationData(IEnumerable<IAttackableUnit> gameObjects);
        CastInfo TranslateCastInfo(IObjAiBase caster, ISpellInstance spell, string spellName, uint? projectileNetId);
    }
}