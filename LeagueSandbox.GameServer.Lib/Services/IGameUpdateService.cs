using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal interface IGameUpdateService
    {
        void UpdateGame(IGame game, float milisecondDiff);
    }
}
