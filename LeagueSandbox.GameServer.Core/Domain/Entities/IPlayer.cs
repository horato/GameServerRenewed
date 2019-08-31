using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IPlayer
    {
        ulong SummonerId { get; }
        int SummonerLevel { get; }
        Rank Rank { get; }
        string SummonerName { get; }
        byte BadgeAlly { get; }
        byte BadgeEnemy { get; }
        int Icon { get; }
        IDictionary<int, int> Runes { get; }
        IObjAiHero Champion { get; }
        void LoadingFinished();
        bool IsLoaded { get; }
    }
}