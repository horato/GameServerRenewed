using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellFactory
    {
        ISpell CreateFromSpellData(SpellSlot slot, string spellName, int maxLevel, ISpellData data);
        ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, int maxLevel, ISpellData data);
    }
}