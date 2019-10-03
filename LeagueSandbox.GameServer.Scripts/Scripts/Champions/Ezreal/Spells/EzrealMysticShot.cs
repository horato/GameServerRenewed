﻿using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Scripts.Base;

namespace LeagueSandbox.GameServer.Scripts.Scripts.Champions.Ezreal.Spells
{
    public class EzrealMysticShot : SpellScriptBase
    {
        public EzrealMysticShot(ISpellCastHelperService spellCastHelperService) : base(spellCastHelperService)
        {
        }

        public override void OnCastFinished(IObjAiBase obj, ISpellInstance spell, ISpellData spellData)
        {
            var extraSpell = obj.SpellBook.GetSpell(SpellSlot.ExtraSpell1);
            CastSpell(obj, extraSpell, spell.Target, spell.TargetPosition, spell.TargetEndPosition);
        }
    }
}
