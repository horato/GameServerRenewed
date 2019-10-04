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
            var movementSpeed = gameObject.Stats.MoveSpeed.Total;
            var destinationReached = MoveObject(gameObject, to, movementSpeed, diff);
            if (!destinationReached)
                return;

            gameObject.OnMovementPointReached(to);
        }

        public bool MoveObject(IGameObject gameObject, Vector2 to, float movementSpeed, float millisecondsDiff)
        {
            var currentPosition = gameObject.Position;
            var from = currentPosition.ToVector2();
            var calculationResult = _calculationService.CalculateNewPosition(from, to, movementSpeed, millisecondsDiff);
            var newPosition = calculationResult.Result.ToVector3(currentPosition.Y);
            gameObject.SetPosition(newPosition);

            return calculationResult.IsDestinationReached;
        }
    }
}