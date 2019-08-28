using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal interface IGameController
    {
        void Initialize(MapType mapId);
        void StartGameLoop();
        void StopGameLoop();
    }
}