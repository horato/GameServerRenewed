using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class GameUpdateService : IGameUpdateService
    {
        public void UpdateGame(IGame game, float millisecondDiff)
        {
            if (game.IsPaused)
                return;

            game.ApplyGameTimeDiff(millisecondDiff);
            //TODO: Game time update
        }
    }
}