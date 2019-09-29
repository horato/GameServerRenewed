using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class CastSpellAns : BasePacket
    {
        public int CasterPositionSyncID { get; set; }
        public bool Unknown1 { get; set; } //if this is false CasterPositionSyncID is used ?
        public CastInfo CastInfo { get; set; }

        public CastSpellAns(uint netId, int casterPositionSyncId, bool unknown1, CastInfo castInfo) : base(PacketCmd.S2CCastSpellAns, netId)
        {
            CasterPositionSyncID = casterPositionSyncId;
            Unknown1 = unknown1;
            CastInfo = castInfo;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteInt(CasterPositionSyncID);

            byte bitfield = 0;
            if (Unknown1)
                bitfield |= 1;

            WriteByte(bitfield);
            GetWriter().WriteCastInfo(CastInfo);
        }
    }
}