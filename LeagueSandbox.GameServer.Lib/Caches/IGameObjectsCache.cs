using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal interface IGameObjectsCache
    {
        void Add(ulong summonerId, IGameObject gameObject);
        bool UserExists(ulong summonerId);
        IGameObject GetObject(ulong summonerId);
        IEnumerable<IGameObject> GetAllObjects();
        IEnumerable<IGameObject> FindByCriteria(Func<IGameObject, bool> criteria);
    }
}
