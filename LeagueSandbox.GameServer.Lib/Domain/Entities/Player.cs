using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities
{
    internal class Player : IPlayer
    {
        public ulong SummonerId { get; }
        public int SummonerLevel { get; }
        public Rank Rank { get; }
        public string SummonerName { get; }
        public byte BadgeAlly { get; }
        public byte BadgeEnemy { get; }
        public int Icon { get; }
        public IDictionary<int, int> Runes { get; }
        public IObjAiHero Champion { get; }

        public Player(ulong summonerId, int summonerLevel, Rank rank, string summonerName, byte badgeAlly, byte badgeEnemy, int icon, IObjAiHero champion, IDictionary<int, int> runes)
        {
            SummonerId = summonerId;
            SummonerLevel = summonerLevel;
            Rank = rank;
            SummonerName = summonerName;
            BadgeAlly = badgeAlly;
            BadgeEnemy = badgeEnemy;
            Icon = icon;
            Champion = champion;
            Runes = runes ?? new Dictionary<int, int>();
        }
    }
}
