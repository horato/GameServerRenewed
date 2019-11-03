using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Services;
using Unity;

namespace LeagueSandbox.GameServer.Scripts.Base
{
    public abstract class SpellScriptBase : ISpellScript
    {
        private readonly ISpellCastHelperService _spellCastHelperService;
        private readonly IDamageHelperService _damageHelperService;

        public virtual bool IsMissileDestroyedOnHit { get; } = false;

        protected SpellScriptBase(IUnityContainer container)
        {
            // using container directly to avoid changing all of the constructors when something needs to be added
            _spellCastHelperService = container.Resolve<ISpellCastHelperService>();
            _damageHelperService = container.Resolve<IDamageHelperService>();
        }

        public virtual void OnCastFinished(IObjAiBase obj, ISpellInstance spell, ISpellData spellData)
        {

        }

        public virtual void OnMissileDestinationReached(IMissile missile)
        {

        }

        public virtual void OnMissileCollision(IMissile missile, IEnumerable<IGameObject> colliders)
        {
            var damageType = GetSpellDamageType();
            foreach (var collider in colliders.OfType<IAttackableUnit>())
            {
                _damageHelperService.DealAutoAttackDamage(missile.Caster, collider, missile.Spell.Definition, damageType);
            }
        }

        protected virtual DamageType GetSpellDamageType()
        {
            return DamageType.Physical;
        }

        protected void CastSpell(IObjAiBase caster, ISpell spell, IAttackableUnit target, Vector2 targetPosition, Vector2 targetPositionEnd)
        {
            _spellCastHelperService.CastSpell(spell, target, caster, targetPosition, targetPositionEnd);
        }
    }
}
