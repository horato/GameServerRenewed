using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class MovementService : IMovementService
    {
        private readonly ICalculationService _calculationService;

        public MovementService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public void MoveObject(IObjAiBase gameObject, float millisecondsDiff)
        {
            if (!gameObject.IsMoving)
                return;

            var to = gameObject.Waypoints.First();
            Move(gameObject, millisecondsDiff, to);
        }

        private void Move(IObjAiBase gameObject, float diff, Vector2 to)
        {
            var currentPosition = gameObject.Position;
            var from = currentPosition.ToVector2();
            var calculationResult = _calculationService.CalculateNewPosition(from, to, gameObject.Stats.MoveSpeed.Total, diff);

            var newPosition = calculationResult.Result.ToVector3(currentPosition.Z);
            gameObject.SetPosition(newPosition);

            if (!calculationResult.IsDestinationReached)
                return;

            gameObject.OnMovementPointReached(to);
        }

    }
}