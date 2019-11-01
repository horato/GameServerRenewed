using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Core.Data
{
    public interface IBaseSpellData
    {
        string Name { get; }
        int MaxLevelOverride { get; }
        IReadOnlyList<int> UpgradeLevels { get; }
    }
}