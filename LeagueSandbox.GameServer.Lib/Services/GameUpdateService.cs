using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class GameUpdateService : IGameUpdateService
    {
        public void UpdateGame(IGame game, float milisecondDiff)
        {
            if (game.IsPaused)
                return;

            game.ApplyGameTimeDiff(milisecondDiff);
        }
    }
}