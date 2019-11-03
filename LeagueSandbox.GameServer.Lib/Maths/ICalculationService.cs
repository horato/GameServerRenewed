using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Maths.DTO;

namespace LeagueSandbox.GameServer.Lib.Maths
{
    internal interface ICalculationService
    {
        PositionCalculationResult CalculateNewPosition(Vector2 from, Vector2 to, float movementSpeed, float millisecondDiff);
        float CalculateManaCost(ISpell spell, IAttackableUnit unit);
        float CalculateManaDifferenceAfterSpellCast(IAttackableUnit unit, float manaCost);
        float CalculateDistance(IGameObject from, IGameObject to);
        Vector2 CalculateDirection(Vector2 start, Vector2 destination);
        Vector3 CalculateDirection(Vector3 start, Vector3 destination);
        Vector3 CalculateVelocity(Vector3 previousLocation, Vector3 currentLocation, float timeDelta);
        bool CalculateCollision(IGameObject obj1, IGameObject obj2);
        Vector2 CalculateDestination(Vector2 from, Vector2 to, float distance);
        float CalculateStatDifference(float currentValue, float newValue, float maxValue, float minValue);
        float CalculateStatDifferenceForLevelUp(float baseValue, float bonusPerLevel, float levelDifference);
        float CalculateStatDifferenceSubstract(float currentValue, float delta, float healthPointsTotal, float min = 0);
        float CalculateStatDifferenceAdd(float currentValue, float delta, float max, float min = 0);
    }
}
