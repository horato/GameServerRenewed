using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal interface IGameUpdateService
    {
        void UpdateGame(IGame game, float millisecondDiff);
    }
}
