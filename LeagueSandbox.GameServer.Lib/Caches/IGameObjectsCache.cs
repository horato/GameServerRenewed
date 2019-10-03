using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal interface IGameObjectsCache
    {
        void Add(uint netId, IGameObject gameObject);
        bool UserExists(uint netId);
        IGameObject GetObject(uint netId);
        IEnumerable<IGameObject> GetAllObjects();
        IEnumerable<IGameObject> FindByCriteria(Func<IGameObject, bool> criteria);
        void Remove(uint netId);
    }
}
