using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class AvatarInfo : BasePacket
    {
        private readonly IList<uint> _itemIDs;
        private readonly IList<SummonerSpellHash> _summonerSpellIDs;
        private readonly IList<Talent> _talents;
        private readonly byte _summonerLevel;
        private readonly byte _wardSkin;

        public AvatarInfo(uint netId, IEnumerable<uint> itemIDs, IEnumerable<SummonerSpellHash> summonerSpellIDs, IEnumerable<Talent> talents, byte summonerLevel, byte wardSkin) : base(PacketCmd.S2CAvatarInfo, netId)
        {
            _itemIDs = itemIDs?.ToList() ?? new List<uint>();
            _summonerSpellIDs = summonerSpellIDs?.ToList() ?? new List<SummonerSpellHash>();
            _talents = talents?.ToList() ?? new List<Talent>();
            _summonerLevel = summonerLevel;
            _wardSkin = wardSkin;

            WritePacket();
        }

        private void WritePacket()
        {
            if (_itemIDs.Count > 30)
                throw new InvalidOperationException("Max 30 item ids");
            if (_summonerSpellIDs.Count > 2)
                throw new InvalidOperationException("Max 2 summoner spells");
            if (_talents.Count > 80)
                throw new InvalidOperationException("Max 80 talents");

            foreach (var item in _itemIDs)
                WriteUInt(item);
            for (var i = 0; i < 30 - _itemIDs.Count; i++)
                WriteUInt(0);

            foreach (var summonerSpell in _summonerSpellIDs)
                WriteUInt((uint)summonerSpell);
            for (var i = 0; i < 2 - _summonerSpellIDs.Count; i++)
                WriteUInt(0);

            foreach (var talent in _talents)
            {
                WriteUInt(talent.Hash);
                WriteByte(talent.Level);
            }

            for (var i = 0; i < 80 - _talents.Count; i++)
            {
                WriteUInt(0);
                WriteByte(0);
            }

            WriteByte(_summonerLevel);
            WriteByte(_wardSkin);
        }
    }

    internal class Talent
    {
        public uint Hash { get; }
        public byte Level { get; }

        public Talent(uint hash, byte level)
        {
            Hash = hash;
            Level = level;
        }
    }
}