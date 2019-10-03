using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Maths.DTO;

namespace LeagueSandbox.GameServer.Lib.Maths
{
    internal interface ICalculationService
    {
        PositionCalculationResult CalculateNewPosition(Vector2 from, Vector2 to, float movementSpeed, float millisecondDiff);
        float CalculateManaCost(ISpell spell, IObjAiHero champion);
        float CalculateManaDifferenceAfterSpellCast(IObjAiHero champion, float manaCost);
        float CalculateDistance(IObjAiHero champion, IAttackableUnit targetUnit);
        Vector2 CalculateDirection(Vector2 start, Vector2 destination);
        Vector3 CalculateDirection(Vector3 start, Vector3 destination);
        Vector3 CalculateVelocity(Vector3 previousLocation, Vector3 currentLocation, float timeDelta);
    }
}
