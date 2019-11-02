using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Scripts.Base;

namespace LeagueSandbox.GameServer.Scripts.Scripts.Champions.Ezreal.Spells
{
    public class EzrealBasicAttack : SpellScriptBase
    {
        public override bool IsMissileDestroyedOnHit => true;

        public EzrealBasicAttack(ISpellCastHelperService spellCastHelperService) : base(spellCastHelperService)
        {
        }

        public override void OnMissileCollision(IMissile missile, IEnumerable<IGameObject> colliders)
        {
            Console.WriteLine("Hit");
        }
    }
}
