using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Lib.Maths.DTO;

namespace LeagueSandbox.GameServer.Lib.Maths
{
    internal interface ICalculationService
    {
        PositionCalculationResult CalculateNewPosition(Vector2 from, Vector2 to, float movementSpeed, float millisecondDiff);
    }
}
