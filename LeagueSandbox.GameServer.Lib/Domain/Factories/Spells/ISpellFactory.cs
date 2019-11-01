using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellFactory
    {
        ISpell CreateFromSpellData(SpellSlot slot, IBaseSpellData baseSpellData, ISpellData data);
        ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, int maxLevel, ISpellData data);
    }
}