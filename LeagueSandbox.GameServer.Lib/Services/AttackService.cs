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
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class AttackService : IAttackService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly ICalculationService _calculationService;
        private readonly IPathingService _pathingService;
        private readonly INetworkIdCreationService _networkIdCreationService;

        public AttackService(IPacketNotifier packetNotifier, IPlayerCache playerCache, ICalculationService calculationService, IPathingService pathingService, INetworkIdCreationService networkIdCreationService)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _calculationService = calculationService;
            _pathingService = pathingService;
            _networkIdCreationService = networkIdCreationService;
        }

        public void Attack(IObjAiBase gameObject, float millisecondsDiff)
        {
            if (!gameObject.IsAttacking)
                return;

            var secondsDiff = millisecondsDiff / 1000.0f;
            gameObject.AttackDelayProgress(secondsDiff);
            gameObject.AttackCooldownProgress(secondsDiff);
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
            var distance = _calculationService.CalculateDistance(gameObject, gameObject.AttackTarget);
            if (distance > gameObject.Stats.Range.Total)
            {
                MoveAndAttackAgain(gameObject);
                return;
            }

            if (gameObject.CurrentAutoAttackCooldown > 0)
                return;

            if (gameObject.IsMoving)
                gameObject.StopMovement();

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); //TODO: vision
            var projectileNetId = gameObject.IsMelee ? 0 : _networkIdCreationService.GetNewNetId();

            // TODO: next aa
            if (true)
                _packetNotifier.NotifyAutoAttackStart(targetSummonerIds, gameObject, projectileNetId);
            else
                _packetNotifier.NotifyAutoAttack(targetSummonerIds, gameObject, projectileNetId);

            _packetNotifier.NotifyUnitSetLookAt(targetSummonerIds, gameObject, gameObject.AttackTarget);

            gameObject.Attacking(projectileNetId);
        }

        private void MoveAndAttackAgain(IObjAiBase gameObject)
        {
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
            if (gameObject.CurrentAutoAttackDelay > 0)
                return;

            //TODO: cast AA spell

            gameObject.WindingUp();
        }

        private void WindupProgress(IObjAiBase gameObject)
        {
            if (gameObject.CurrentAutoAttackDelay > 0)
                return;

            gameObject.AttackFinished();
        }

        private void AttackFinished(IObjAiBase gameObject)
        {
            MoveAndAttackAgain(gameObject);
        }
    }
}
