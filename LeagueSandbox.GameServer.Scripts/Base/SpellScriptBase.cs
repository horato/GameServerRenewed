using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Services;

namespace LeagueSandbox.GameServer.Scripts.Base
{
    public abstract class SpellScriptBase : ISpellScript
    {
        private readonly ISpellCastHelperService _spellCastHelperService;

        protected SpellScriptBase(ISpellCastHelperService spellCastHelperService)
        {
            _spellCastHelperService = spellCastHelperService;
        }

        public virtual void OnCastFinished(IObjAiBase obj, ISpellInstance spell, ISpellData spellData)
        {

        }

        protected void CastSpell(IObjAiBase caster, ISpell spell, IAttackableUnit target, Vector2 targetPosition, Vector2 targetPositionEnd)
        {
            _spellCastHelperService.CastSpell(spell, target, caster, targetPosition, targetPositionEnd);
            //_spellCastHelperService.CastSpell(caster, spell, originalSpellInstance);
        }
    }
}
