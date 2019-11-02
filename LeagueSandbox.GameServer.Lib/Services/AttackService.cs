using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Maths;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class AttackService : IAttackService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly ICalculationService _calculationService;
        private readonly IPathingService _pathingService;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ISpellCastHelperService _spellCastHelperService;
        private readonly ISpellDataProvider _spellDataProvider;
        private readonly ISpellFactory _spellFactory;

        public AttackService(IPacketNotifier packetNotifier, IPlayerCache playerCache, ICalculationService calculationService, IPathingService pathingService, INetworkIdCreationService networkIdCreationService, ISpellCastHelperService spellCastHelperService, ISpellDataProvider spellDataProvider, ISpellFactory spellFactory)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _calculationService = calculationService;
            _pathingService = pathingService;
            _networkIdCreationService = networkIdCreationService;
            _spellCastHelperService = spellCastHelperService;
            _spellDataProvider = spellDataProvider;
            _spellFactory = spellFactory;
        }

        public void Attack(IObjAiBase gameObject, float millisecondsDiff)
        {
            var secondsDiff = millisecondsDiff / 1000.0f;
            gameObject.AttackDelayProgress(secondsDiff);
            gameObject.AttackCooldownProgress(secondsDiff);

            if (!gameObject.IsAttacking)
                return;

            switch (gameObject.AutoAttackState)
            {
                case AutoAttackState.Preparing:
                    BeginAttack(gameObject);
                    break;
                case AutoAttackState.Attacking:
                    AttackProgress(gameObject);
                    break;
                case AutoAttackState.Windup:
                    WindupProgress(gameObject);
                    break;
                case AutoAttackState.Finished:
                    AttackFinished(gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void BeginAttack(IObjAiBase gameObject)
        {
            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} is attempting to auto attack. Cooldown remaining: {gameObject.CurrentAutoAttackCooldown}");

            var distance = _calculationService.CalculateDistance(gameObject, gameObject.AttackTarget);
            if (distance > gameObject.Stats.Range.Total)
            {
                LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} doesn't have enough range to AA");
                MoveAndAttackAgain(gameObject);
                return;
            }

            if (gameObject.CurrentAutoAttackCooldown > 0)
                return;

            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} is beginning AA");

            if (gameObject.IsMoving)
                gameObject.StopMovement();

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); //TODO: vision
            var projectileNetId = gameObject.CharacterData.Flags.HasFlag(CharDataFlags.Melee) ? 0 : _networkIdCreationService.GetNewNetId();

            // ??
            //if (true)
            //    _packetNotifier.NotifyAutoAttackStart(targetSummonerIds, gameObject, projectileNetId);
            //else
            //    _packetNotifier.NotifyAutoAttack(targetSummonerIds, gameObject, projectileNetId);

            _packetNotifier.NotifyUnitSetLookAt(targetSummonerIds, gameObject, gameObject.AttackTarget);

            gameObject.Attacking(projectileNetId);
        }

        private void MoveAndAttackAgain(IObjAiBase gameObject)
        {
            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} is preparing for another attack");

            var path = _pathingService.FindPath(gameObject.Position.ToVector2(), gameObject.AttackTarget.Position.ToVector2()).ToList();
            if (!path.Any())
            {
                //TODO: figure this out and remove
                LoggerProvider.GetLogger().Warn($"No path found from {gameObject.Position} to {gameObject.AttackTarget.Position}");
                return;
            }

            gameObject.Attack(gameObject.AttackTarget, path, gameObject.MovementType);
        }

        private void AttackProgress(IObjAiBase gameObject)
        {
            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName}'s AA progress. Current delay {gameObject.CurrentAutoAttackDelay}");
            if (gameObject.CurrentAutoAttackDelay > 0)
                return;
            
            var baseAttack = gameObject.CharacterData.AttacksData[SpellSlot.BaseAttack];
            var spellData = _spellDataProvider.ProvideCharacterSpellData(gameObject.SkinName, baseAttack.Name);
            var baseSpellData = new BaseSpellData(baseAttack.Name, 1, new List<int>());
            var spell = _spellFactory.CreateFromSpellData(SpellSlot.BaseAttack, baseSpellData, spellData);

            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} is casting {baseAttack.Name}");
            _spellCastHelperService.CastSpell(spell, gameObject.AttackTarget, gameObject, gameObject.AttackTarget.Position.ToVector2(), gameObject.AttackTarget.Position.ToVector2(), gameObject.AutoAttackProjectileId);

            gameObject.WindingUp();
        }

        private void WindupProgress(IObjAiBase gameObject)
        {
            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName} windup progress. Current delay: {gameObject.CurrentAutoAttackDelay}");
            if (gameObject.CurrentAutoAttackDelay > 0)
                return;

            gameObject.AttackFinished();
        }

        private void AttackFinished(IObjAiBase gameObject)
        {
            LoggerProvider.GetLogger().Debug($"{gameObject.SkinName}'s AA finished");

            MoveAndAttackAgain(gameObject);
        }
    }
}
