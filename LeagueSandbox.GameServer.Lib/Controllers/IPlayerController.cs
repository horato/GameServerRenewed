using System.Collections.Generic;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal interface IPlayerController
    {
        IEnumerable<ObjAiHero> GetAllChampions();
    }
}