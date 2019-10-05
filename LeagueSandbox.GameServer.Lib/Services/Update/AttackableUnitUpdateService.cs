using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class AttackableUnitUpdateService : IAttackableUnitUpdateService
    {
        private readonly IStatsUpdateService _statsUpdateService;

        public AttackableUnitUpdateService(IStatsUpdateService statsUpdateService)
        {
            _statsUpdateService = statsUpdateService;
        }

        public void Update(IAttackableUnit attackableUnit, float millisecondsDiff)
        {
            _statsUpdateService.Update(attackableUnit, millisecondsDiff);
        }
    }
}