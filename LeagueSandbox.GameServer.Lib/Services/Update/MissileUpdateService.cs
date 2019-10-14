using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class MissileUpdateService : IMissileUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IMovementService _movementService;
        private readonly ISpellScriptProvider _spellScriptProvider;
        private readonly ICollisionService _collisionService;

        public MissileUpdateService(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGameObjectsCache gameObjectsCache, IMovementService movementService, ISpellScriptProvider spellScriptProvider, ICollisionService collisionService)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _gameObjectsCache = gameObjectsCache;
            _movementService = movementService;
            _spellScriptProvider = spellScriptProvider;
            _collisionService = collisionService;
        }

        public void Update(IMissile missile, float millisecondsDiff)
        {
            switch (missile.MissileState)
            {
                case MissileState.Created:
                    LaunchMissile(missile);
                    break;
                case MissileState.Traveling:
                    MissileTraveling(missile, millisecondsDiff);
                    break;
                case MissileState.Arrived:
                case MissileState.Terminated:
                    MissileFinished(missile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LaunchMissile(IMissile missile)
        {
            missile.Launched();

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
            _packetNotifier.NotifyMissileReplication(targetSummonerIds, missile);
        }

        private void MissileTraveling(IMissile missile, float millisecondsDiff)
        {
            var colliders = _collisionService.FindAttackableObjectsCollidingWith(missile).ToList();
            colliders.RemoveAll(x => !IsValidTarget(x, missile));

            if (colliders.Any())
            {
                MissileCollided(missile, colliders);
                if (missile.DestroyOnHit)
                {
                    missile.Terminated();
                    return;
                }
            }

            var to = missile.EndPoint.ToVector2();
            var destinationReached = _movementService.MoveObject(missile, to, missile.Speed, millisecondsDiff);
            if (destinationReached)
                missile.DestinationReached();
        }

        private bool IsValidTarget(IGameObject unit, IMissile missile)
        {
            var caster = missile.Caster;
            var spellDefinition = missile.Spell.Definition;
            if (unit.Team == caster.Team && !spellDefinition.HasFlag(SpellFlags.AffectFriends))
                return false;
            if (unit.Team == Team.Neutral && !spellDefinition.HasFlag(SpellFlags.AffectNeutral))
                return false;
            if (unit.Team != caster.Team && unit.Team != Team.Neutral && !spellDefinition.HasFlag(SpellFlags.AffectEnemies))
                return false;
            //if (unit.IsDead && !spellDefinition.HasFlag(SpellFlags.AffectDead)) TODO: is dead
            //    return false;

            switch (unit)
            {
                case IObjAiMinion minion when minion.IsLaneMinion && spellDefinition.HasFlag(SpellFlags.AffectMinions):
                    return true;
                case IObjAiMinion minion when !minion.IsLaneMinion && spellDefinition.HasFlag(SpellFlags.AffectUseable):
                    return true;
                case IObjAiTurret _ when spellDefinition.HasFlag(SpellFlags.AffectTurrets):
                    return true;
                case IObjBarracksDampener _ when spellDefinition.HasFlag(SpellFlags.AffectBuildings):
                case IObjHQ _ when spellDefinition.HasFlag(SpellFlags.AffectBuildings):
                    return true;
                case IObjAiHero _ when spellDefinition.HasFlag(SpellFlags.AffectHeroes):
                    return true;
                default:
                    return false;
            }
        }

        private void MissileCollided(IMissile missile, IEnumerable<IGameObject> colliders)
        {
            if (!_spellScriptProvider.SpellScriptExists(missile.Caster.SkinName, missile.Spell.Definition.SpellName))
                return;

            var script = _spellScriptProvider.ProvideSpellScript(missile.Caster.SkinName, missile.Spell.Definition.SpellName);
            var actualColliders = missile.DestroyOnHit ? new[] { colliders.First() } : colliders; // To prevent single target skillshots to hit multiple targets
            script.OnMissileCollision(missile, actualColliders);
        }

        private void MissileFinished(IMissile missile)
        {
            if (missile.MissileState == MissileState.Arrived && _spellScriptProvider.SpellScriptExists(missile.Caster.SkinName, missile.Spell.Definition.SpellName))
            {
                var script = _spellScriptProvider.ProvideSpellScript(missile.Caster.SkinName, missile.Spell.Definition.SpellName);
                script.OnMissileDestinationReached(missile);
            }

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
            _packetNotifier.NotifyDestroyMissile(targetSummonerIds, missile);
            _gameObjectsCache.Remove(missile.NetId);
        }
    }
}