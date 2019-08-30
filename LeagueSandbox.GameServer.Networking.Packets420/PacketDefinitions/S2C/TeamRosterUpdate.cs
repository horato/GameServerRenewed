using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class TeamRosterUpdate : Packet
    {
        public uint TeamSizeOrder { get; }
        public uint TeamSizeChaos { get; }
        public IList<ulong> OrderMembers { get; }
        public IList<ulong> ChaosMembers { get; }
        public uint TeamSizeOrderCurrent { get; }
        public uint TeamSizeChaosCurrent { get; }

        private void WritePacket()
        {
            if (OrderMembers.Count > 24)
                throw new InvalidOperationException("Max 24 order members");
            if (ChaosMembers.Count > 24)
                throw new InvalidOperationException("Max 24 chaos members");

            WriteUInt(TeamSizeOrder);
            WriteUInt(TeamSizeChaos);

            foreach (var member in OrderMembers)
                WriteULong(member);
            for (var i = 0; i < 24 - OrderMembers.Count; i++)
                WriteULong(0);

            foreach (var member in ChaosMembers)
                WriteULong(member);
            for (var i = 0; i < 24 - ChaosMembers.Count; i++)
                WriteULong(0);

            WriteUInt(TeamSizeOrderCurrent);
            WriteUInt(TeamSizeChaosCurrent);
        }

        public TeamRosterUpdate(IEnumerable<ulong> orderMembers, IEnumerable<ulong> chaosMembers, uint teamSizeOrderCurrent, uint teamSizeChaosCurrent) : base(PacketCmd.S2CTeamRosterUpdate)
        {
            OrderMembers = orderMembers?.ToList() ?? new List<ulong>();
            ChaosMembers = chaosMembers?.ToList() ?? new List<ulong>();
            TeamSizeOrder = (uint)OrderMembers.Count;
            TeamSizeChaos = (uint)ChaosMembers.Count;
            TeamSizeOrderCurrent = teamSizeOrderCurrent;
            TeamSizeChaosCurrent = teamSizeChaosCurrent;

            WritePacket();
        }
    }
}