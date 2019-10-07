using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting.DTO;

namespace LeagueSandbox.GameServer.Scripts.Base.DTOs
{
    internal class NamedMinionInfo
    {
        public string Name { get; }
        public MinionType Type { get; }
        public Team Team { get; }
        public MinionInfo Info { get; }

        public NamedMinionInfo(string name, MinionType type, Team team, MinionInfo info)
        {
            Name = name;
            Type = type;
            Team = team;
            Info = info;
        }
    }
}