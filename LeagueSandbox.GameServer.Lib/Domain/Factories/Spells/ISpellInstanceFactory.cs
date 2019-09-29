using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellInstanceFactory
    {
        ISpellInstance CreateNew(ISpell spell, Vector2 position, Vector2 endPosition, IAttackableUnit targetUnit);
    }
}