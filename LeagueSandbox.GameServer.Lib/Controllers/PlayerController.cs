using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class PlayerController : IPlayerController
    {
        private readonly IGameObjectsCache _gameObjectsCache;

        public PlayerController(IGameObjectsCache gameObjectsCache)
        {
            _gameObjectsCache = gameObjectsCache;
        }

        public IEnumerable<ObjAiHero> GetAllChampions()
        {
            return _gameObjectsCache.GetAllObjects().OfType<ObjAiHero>();
        }
    }
}
