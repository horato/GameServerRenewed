using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal class GameObjectsCache : IGameObjectsCache
    {
        private readonly IDictionary<uint, IGameObject> _gameObjects = new ConcurrentDictionary<uint, IGameObject>();

        public void Add(uint netId, IGameObject gameObject)
        {
            if (UserExists(netId))
                throw new InvalidOperationException($"Object {netId} already exists");

            _gameObjects.Add(netId, gameObject);
        }

        public bool UserExists(uint netId)
        {
            return _gameObjects.ContainsKey(netId);
        }

        public IGameObject GetObject(uint netId)
        {
            if (!UserExists(netId))
                throw new InvalidOperationException($"Object {netId} does not exist.");

            return _gameObjects[netId];
        }

        public IEnumerable<IGameObject> GetAllObjects()
        {
            return _gameObjects.Values.ToList();
        }

        // I suspect this method might have performance issues because of linq queries.
        // In that case refactoring will have to take place.
        // Replace this method with several FindByXXX methods and add corresponding dictionaries with different keys
        public IEnumerable<IGameObject> FindByCriteria(Func<IGameObject, bool> criteria)
        {
            return _gameObjects.Values.Where(criteria);
        }

        public void Remove(uint netId)
        {
            var obj = GetObject(netId);
            if (obj is IObjAiHero)
                throw new InvalidOperationException("Player objects cannot be removed.");

            _gameObjects.Remove(netId);
        }
    }
}