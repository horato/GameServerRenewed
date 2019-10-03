using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Scripts.Base
{
    public abstract class SpellScriptBase : ISpellScript
    {
        public virtual void OnCastFinished(IObjAiBase objAiBase, ISpellInstance spell, ISpellData spellData)
        {
            
        }

        protected void CastSpell(string spellName, Vector2 targetPosition, Vector2 targetPositionEnd, IAttackableUnit target)
        {

        }
    }
}
