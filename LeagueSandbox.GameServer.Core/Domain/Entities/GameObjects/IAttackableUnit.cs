using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IAttackableUnit : IGameObject
    {
        IStats Stats { get; }
    }
}