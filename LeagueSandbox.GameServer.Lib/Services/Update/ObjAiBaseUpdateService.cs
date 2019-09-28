using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class ObjAiBaseUpdateService : IObjAiBaseUpdateService
    {
        private readonly IMovementService _movementService;

        public ObjAiBaseUpdateService(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public void Update(IObjAiBase aiBase, float millisecondsDiff)
        {
            _movementService.MoveObject(aiBase, millisecondsDiff);
        }
    }
}