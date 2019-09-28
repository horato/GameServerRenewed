using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellFactory
    {
        ISpell CreateNew(SpellSlot slot, int level, float castTime, string spellName, int maxLevel, float cooldownRemaining, IDictionary<int, float> cooldownPerLevelMap, IDictionary<int, float> manaCostPerLevelMap, IDictionary<int, float> castRangePerLevelMap, IDictionary<int, float> channelDurationPerLevelMap);
        ISpell CreateFromSpellData(SpellSlot slot, string spellName, int maxLevel, SpellData data);
        ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, int maxLevel, SpellData data);
    }
}