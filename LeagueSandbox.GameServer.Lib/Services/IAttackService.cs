using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal interface IAttackService
    {
        void Attack(IObjAiBase gameObject, float millisecondsDiff);
    }
}