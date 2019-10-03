using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Core.Services
{
    public interface ISpellCastHelperService
    {
        void CastSpell(ISpell spell, IAttackableUnit targetUnit, IObjAiBase caster, Vector2 targetPosition, Vector2 targetPositionEnd);
    }
}
