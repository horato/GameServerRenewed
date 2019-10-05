using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class SkillUpServerAction : ServerActionBase<SkillUpRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;

        public SkillUpServerAction(IPlayerCache playerCache, IPacketNotifier packetNotifier)
        {
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, SkillUpRequest request)
        {
            // TODO: Implement evolve (kazix, ...)
            // TODO: Add skillup logic (ult only 6+, etc)
            if (request.IsEvolve)
                throw new NotImplementedException("Evolve is not implemented yet");

            var player = _playerCache.GetPlayer(senderSummonerId);
            var champion = player.Champion;
            var spellBook = champion.SpellBook;
            if (spellBook.SkillPoints < 1)
                throw new InvalidOperationException($"Player {senderSummonerId} tried to skill up without available points");

            var spell = spellBook.GetSpell(request.Skill);
            var targetLevel = spell.Level + 1;
            if (targetLevel > spell.MaxLevel)
                throw new InvalidOperationException($"Player {senderSummonerId} tried to skill up spell {spell.SpellName} past its max level (target:{targetLevel}, max:{spell.MaxLevel})");

            spell.SetLevel(targetLevel);
            spellBook.SkillPointUsed();
            champion.Stats.SetSpellEnabled(spell.Slot, spell.Level > 0);

            _packetNotifier.NotifySkillUp(champion.SummonerId, champion, spell);
        }
    }
}
