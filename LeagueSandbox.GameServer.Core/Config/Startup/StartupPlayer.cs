using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Config.Startup
{
    /// <summary> Represents a future player that will connect to the game. </summary>
    public class StartupPlayer
    {
        public ulong SummonerId { get; }
        public ushort SummonerLevel { get; }
        public Rank Rank { get; }
        public string Name { get; }
        public string Champion { get; }
        public Team Team { get; }
        public short Skin { get; }
        public SummonerSpell Summoner1 { get; }
        public SummonerSpell Summoner2 { get; }
        public byte BadgeAlly { get; }
        public byte BadgeEnemy { get; }
        public int Icon { get; }
        public bool IsBot { get; }
        public IDictionary<int, int> Runes { get; }

        public StartupPlayer(ulong summonerId, ushort summonerLevel, Rank rank, string name, string champion, Team team, short skin, SummonerSpell summoner1, SummonerSpell summoner2, byte badgeAlly, byte badgeEnemy, int icon, bool isBot, IDictionary<int, int> runes)
        {
            SummonerId = summonerId;
            SummonerLevel = summonerLevel;
            Rank = rank;
            Name = name;
            Champion = champion;
            Team = team;
            Skin = skin;
            Summoner1 = summoner1;
            Summoner2 = summoner2;
            BadgeAlly = badgeAlly;
            BadgeEnemy = badgeEnemy;
            Icon = icon;
            IsBot = isBot;
            Runes = runes ?? new Dictionary<int, int>();
        }
    }
}
