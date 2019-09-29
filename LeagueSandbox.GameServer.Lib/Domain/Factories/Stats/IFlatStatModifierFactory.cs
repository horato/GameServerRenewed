using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IFlatStatModifierFactory
    {
        IFlatStatModifier CreateNew(float value, float bonusPerLevel, float regenerationPer5, float regenerationBonusPerLevel);
        IFlatStatModifier CreateValueModifier(float value);
    }
}
