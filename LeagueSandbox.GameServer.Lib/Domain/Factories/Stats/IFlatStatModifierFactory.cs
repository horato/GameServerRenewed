using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IFlatStatModifierFactory
    {
        FlatStatModifier CreateNew(float value, float bonusPerLevel, float regenerationPer5, float regenerationBonusPerLevel);
    }
}
