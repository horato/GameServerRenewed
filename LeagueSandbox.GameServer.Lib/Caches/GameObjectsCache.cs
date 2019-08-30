using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal class GameObjectsCache : IGameObjectsCache
    {
        private readonly IDictionary<ulong, IGameObject> _gameObjects = new ConcurrentDictionary<ulong, IGameObject>();

        public void Add(ulong summonerId, IGameObject gameObject)
        {
            if (UserExists(summonerId))
                throw new InvalidOperationException($"Object {summonerId} already exists");

            _gameObjects.Add(summonerId, gameObject);
        }

        public bool UserExists(ulong summonerId)
        {
            return _gameObjects.ContainsKey(summonerId);
        }

        public IGameObject GetObject(ulong summonerId)
        {
            if (!UserExists(summonerId))
                throw new InvalidOperationException($"Object {summonerId} does not exist.");

            return _gameObjects[summonerId];
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
    }
}