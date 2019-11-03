using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Scripts.Base;
using Unity;

namespace LeagueSandbox.GameServer.Scripts.Scripts.Champions.Ezreal.Spells
{
    public class EzrealBasicAttack : SpellScriptBase
    {
        public override bool IsMissileDestroyedOnHit => true;

        public EzrealBasicAttack(IUnityContainer container) : base(container)
        {
        }
    }
}
