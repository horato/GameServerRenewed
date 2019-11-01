using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class SpellFactory : EntityFactoryBase<Spell>, ISpellFactory
    {
        public SpellFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public ISpell CreateFromSpellData(SpellSlot slot, IBaseSpellData baseSpellData, ISpellData data)
        {
            var instance = new Spell(slot, 0, 0, SpellState.Ready, baseSpellData, data);

            return SetupDependencies(instance);
        }

        public ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, int maxLevel, ISpellData data)
        {
            var baseSpellData = new BaseSpellData(spell.ToSpellName(), maxLevel, new List<int>()); // TODO: ??
            var instance = CreateFromSpellData(slot, baseSpellData, data);
            instance.SetLevel(1);

            return instance;
        }
    }
}
