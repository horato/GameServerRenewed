using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface IParticleFactory
    {
        IParticle CreateFromSpellData(IObjAiHero champion, IGameObject target, SpellData data);
    }
}