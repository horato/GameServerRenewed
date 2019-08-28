using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Config.Startup
{
    /// <summary> Represents a future player that will connect to the game. </summary>
    public class StartupPlayer
    {
        public Rank Rank { get; }
        public string Name { get; }
        public string Champion { get; }
        public Team Team { get; }
        public int Skin { get; }
        public SummonerSpell Summoner1 { get; }
        public SummonerSpell Summoner2 { get; }
        public int Ribbon { get; }
        public int Icon { get; }

        public StartupPlayer(Rank rank, string name, string champion, Team team, int skin, SummonerSpell summoner1, SummonerSpell summoner2, int ribbon, int icon)
        {
            Rank = rank;
            Name = name;
            Champion = champion;
            Team = team;
            Skin = skin;
            Summoner1 = summoner1;
            Summoner2 = summoner2;
            Ribbon = ribbon;
            Icon = icon;
        }
    }
}
