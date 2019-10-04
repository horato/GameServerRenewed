using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Core.Scripting
{
    public interface ISpellScript
    {
        void OnCastFinished(IObjAiBase obj, ISpellInstance spell, ISpellData spellData);
        void OnMissileDestinationReached(IMissile missile);
    }
}
