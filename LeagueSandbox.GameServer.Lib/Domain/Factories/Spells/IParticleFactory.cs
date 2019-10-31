using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface IParticleFactory
    {
        IParticle CreateFromSpellData(IObjAiHero champion, IGameObject target, ISpellData data);
    }
}