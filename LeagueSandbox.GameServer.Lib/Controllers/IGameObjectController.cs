using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Config.Startup;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal interface IGameObjectController
    {
        void InitializeGameObjects(IEnumerable<StartupPlayer> players, MapType map);
        void UpdateObjects(float millisecondsDiff);
    }
}