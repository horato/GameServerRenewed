using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Core.Scripting
{
    public interface ISpellScript
    {
        bool IsMissileDestroyedOnHit { get; }

        void OnCastFinished(IObjAiBase obj, ISpellInstance spell, ISpellData spellData);
        void OnMissileDestinationReached(IMissile missile);
        void OnMissileCollision(IMissile missile, IEnumerable<IGameObject> actualColliders);
    }
}
