using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class CollisionService : ICollisionService
    {
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly ICalculationService _calculationService;

        public CollisionService(IGameObjectsCache gameObjectsCache, ICalculationService calculationService)
        {
            _gameObjectsCache = gameObjectsCache;
            _calculationService = calculationService;
        }

        public IEnumerable<IGameObject> FindAttackableObjectsCollidingWith(IGameObject gameObject)
        {
            var result = new List<IGameObject>();
            var objects = _gameObjectsCache.GetAllObjects();
            foreach (var obj in objects)
            {
                // Only attackable units
                if (!(obj is IAttackableUnit))
                    continue;

                // These objects cannot be casted to nor they can be hit with missiles
                if (obj is IObjBuilding || obj is IObjAiTurret || obj is ILevelPropAI)
                    continue;

                // Not self
                if (obj == gameObject)
                    continue;

                var isInCollision = _calculationService.CalculateCollision(gameObject, obj);
                if (isInCollision)
                {
                    result.Add(obj);
                }
            }

            return result.OrderBy(x => _calculationService.CalculateDistance(gameObject, x)).ToList();
        }
    }
}
