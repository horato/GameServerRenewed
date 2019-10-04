using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Scripting;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class MissileUpdateService : IMissileUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IMovementService _movementService;
        private readonly ISpellScriptProvider _spellScriptProvider;

        public MissileUpdateService(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGameObjectsCache gameObjectsCache, IMovementService movementService, ISpellScriptProvider spellScriptProvider)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _gameObjectsCache = gameObjectsCache;
            _movementService = movementService;
            _spellScriptProvider = spellScriptProvider;
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
                    MissileArrived(missile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LaunchMissile(IMissile missile)
        {
            missile.MissileLaunched();

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
            _packetNotifier.NotifyMissileReplication(targetSummonerIds, missile);
        }

        private void MissileTraveling(IMissile missile, float millisecondsDiff)
        {
            //TODO: collision

            var to = missile.EndPoint.ToVector2();
            var destinationReached = _movementService.MoveObject(missile, to, missile.Speed, millisecondsDiff);
            if (destinationReached)
                missile.DestinationReached();
        }

        private void MissileArrived(IMissile missile)
        {
            if (_spellScriptProvider.SpellScriptExists(missile.Caster.SkinName, missile.Spell.Definition.SpellName))
            {
                var script = _spellScriptProvider.ProvideSpellScript(missile.Caster.SkinName, missile.Spell.Definition.SpellName);
                script.OnMissileDestinationReached(missile);
            }

            _gameObjectsCache.Remove(missile.NetId);
        }
    }
}