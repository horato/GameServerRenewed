using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Map.MapObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IStatsFactory
    {
        IStats CreateDefaultStats();
        IStats CreateFromCharacterData(ICharacterData data);
        IStats CreateFromBarrackData(IBarracksData data);
    }
}