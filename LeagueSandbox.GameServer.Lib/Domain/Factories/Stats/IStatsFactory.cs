using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IStatsFactory
    {
        IStats CreateDefaultStats();
        IStats CreateFromCharacterData(CharacterData data);
        IStats CreateFromBarrackData(IBarracksData data);
    }
}