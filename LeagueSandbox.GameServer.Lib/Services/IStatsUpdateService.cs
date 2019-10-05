using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal interface IStatsUpdateService
    {
        void Update(IAttackableUnit unit, float millisecondsDiff);
    }
}