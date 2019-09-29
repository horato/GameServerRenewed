using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface IParticle : IGameObject
    {
        IObjAiBase Source { get; }
        IGameObject Target { get; }
        string Name { get; }
        string BoneName { get; }
        float Size { get; }
    }
}