using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IStatModifierFactory
    {
        StatModifier CreateNew(float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus);
    }
}
