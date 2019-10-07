using System;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Scripts.Base.DTOs
{
    internal class TeamBarrackInfo
    {
        public Lane Lane { get; }
        public Team Team { get; }
        public BarrackInfo Info { get; }
        public MinionInfoTable MinionInfoTable { get; }

        public TeamBarrackInfo(Lane lane, Team team, BarrackInfo info, MinionInfoTable minionInfoTable)
        {
            Lane = lane;
            Team = team;
            Info = info;
            MinionInfoTable = minionInfoTable;
        }
    }
}
