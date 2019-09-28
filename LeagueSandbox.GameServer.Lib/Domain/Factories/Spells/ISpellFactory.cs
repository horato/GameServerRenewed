using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellFactory
    {
        ISpell CreateNew(SpellSlot slot, int level, float castTime, string spellName, float cooldownRemaining, float castTimeRemaining, IDictionary<int, float> cooldownPerLevelMap, IDictionary<int, float> manaCostPerLevelMap, IDictionary<int, float> castRangePerLevelMap);
        ISpell CreateFromSpellData(SpellSlot slot, string spellName, SpellData data);
        ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, SpellData data);
    }
}