using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Config.Startup;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal interface IGameObjectController
    {
        void InitializeChampions(IEnumerable<StartupPlayer> players);
        void UpdateObjects(float millisecondsDiff);
    }
}