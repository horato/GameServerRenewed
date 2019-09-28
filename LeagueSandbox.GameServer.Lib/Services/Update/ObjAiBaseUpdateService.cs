using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class ObjAiBaseUpdateService : IObjAiBaseUpdateService
    {
        private readonly IMovementService _movementService;
        private readonly ISpellbookUpdateService _spellbookUpdateService;

        public ObjAiBaseUpdateService(IMovementService movementService, ISpellbookUpdateService spellbookUpdateService)
        {
            _movementService = movementService;
            _spellbookUpdateService = spellbookUpdateService;
        }

        public void Update(IObjAiBase aiBase, float millisecondsDiff)
        {
            _movementService.MoveObject(aiBase, millisecondsDiff);
            _spellbookUpdateService.UpdateSpellbook(aiBase, millisecondsDiff);
        }
    }
}