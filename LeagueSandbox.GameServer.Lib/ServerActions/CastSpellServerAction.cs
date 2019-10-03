using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Maths;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class CastSpellServerAction : ServerActionBase<CastSpellRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly ISpellCastHelperService _spellCastHelperService;

        public CastSpellServerAction(IPlayerCache playerCache, IGameObjectsCache gameObjectsCache, ISpellCastHelperService spellCastHelperService)
        {
            _playerCache = playerCache;
            _gameObjectsCache = gameObjectsCache;
            _spellCastHelperService = spellCastHelperService;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, CastSpellRequest request)
        {
            var champion = _playerCache.GetPlayer(senderSummonerId).Champion;
            if (!champion.CanCast())
                return;

            var spell = champion.SpellBook.GetSpell(request.Slot);

            // Spell cooldown
            if (spell.State != SpellState.Ready)
                return;

            IAttackableUnit targetUnit = null;
            if (request.TargetNetID != 0)
            {
                var target = _gameObjectsCache.GetObject(request.TargetNetID);
                targetUnit = target as IAttackableUnit ?? throw new InvalidOperationException("Invalid spell target"); //TODO: Check if this is valid business case or not
            }
            
            _spellCastHelperService.CastSpell(spell, targetUnit, champion, request.Position, request.EndPosition);
        }
    }
}
