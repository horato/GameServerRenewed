using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellInstanceFactory
    {
        ISpellInstance CreateNew(ISpell spell, Vector2 targetPosition, Vector2 targetEndPosition, IAttackableUnit targetUnit, float actualManaCost, uint? projectileId = null);
    }
}