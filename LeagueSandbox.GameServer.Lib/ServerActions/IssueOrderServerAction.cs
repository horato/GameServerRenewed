using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Services;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class IssueOrderServerAction : ServerActionBase<IssueOrderRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly ICoordinatesTranslationService _coordinatesTranslationService;
        private readonly IPathingService _pathingService;
        private readonly IGameObjectsCache _gameObjectsCache;

        public IssueOrderServerAction(IPlayerCache playerCache, ICoordinatesTranslationService coordinatesTranslationService, IPathingService pathingService, IGameObjectsCache gameObjectsCache)
        {
            _playerCache = playerCache;
            _coordinatesTranslationService = coordinatesTranslationService;
            _pathingService = pathingService;
            _gameObjectsCache = gameObjectsCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, IssueOrderRequest request)
        {
            var sender = _playerCache.GetPlayer(senderSummonerId);
            switch (request.OrderType)
            {
                case MovementType.Emote:
                    //TODO: check why is this a thing.
                    sender.Champion.StopMovement();
                    break;
                case MovementType.Move:
                case MovementType.Attack:
                case MovementType.Attackmove:
                    //TODO: maybe validate client waypoints and use those?
                    //var clientWaypoints = _coordinatesTranslationService.TranslateCompressedVectorsToMapVectors(request.MovementData.Waypoints.OrderBy(x => x.Order).Select(x => x.Position)).ToList();

                    var currentPosition = sender.Champion.Position.ToVector2();
                    var path = _pathingService.FindPath(currentPosition, request.Position).ToList();
                    if (path.Any())
                    {
                        if (request.OrderType == MovementType.Attack)
                        {
                            var target = _gameObjectsCache.GetObject(request.TargetNetID);
                            if (!(target is IAttackableUnit attackableUnit))
                                throw new InvalidOperationException($"{request.TargetNetID} is not attackable");

                            sender.Champion.Attack(attackableUnit, path, request.OrderType);
                        }
                        else
                        {
                            sender.Champion.Move(path, request.OrderType);
                        }
                    }
                    else
                    {
                        if (!sender.Champion.IsMoving)
                            break;

                        sender.Champion.StopMovement();
                    }

                    break;
                case MovementType.Stop:
                    if (sender.Champion.IsAttacking)
                        sender.Champion.StopAttack();
                    if (sender.Champion.IsMoving)
                        sender.Champion.StopMovement();

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.OrderType), request.OrderType, null);
            }
        }
    }
}
