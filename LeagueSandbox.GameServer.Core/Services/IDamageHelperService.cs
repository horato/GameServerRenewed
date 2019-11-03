using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Services
{
    public interface IDamageHelperService
    {
        void DealAutoAttackDamage(IObjAiBase from, IAttackableUnit to, ISpell spell, DamageType damageType);
        void DealDamage(IObjAiBase from, IAttackableUnit to, ISpell spell, DamageType damageType, float damage);
    }
}
