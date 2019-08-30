using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class CreateHero : BasePacket
    {
        private readonly uint _netId;
        private readonly int _clientId;
        private readonly byte _netNodeId;
        private readonly BotSkillLevel _botSkillLevel;
        private readonly bool _isBlueTeam;
        private readonly bool _isBot;
        private readonly byte _botRank;
        private readonly byte _spawnPositionIndex;
        private readonly int _skinId;
        private readonly string _summonerName;
        private readonly string _championName;
        private readonly float _deathDurationRemaining;
        private readonly float _timeSinceDeath;
        private readonly CreateHeroDeath _createHeroDeath;
        private readonly bool _unknown1; // something with scripts
        private readonly bool _unknown2; // something with spawn

        public CreateHero(uint netId, int clientId, byte netNodeId, BotSkillLevel botSkillLevel, bool isBlueTeam, bool isBot, byte botRank, byte spawnPositionIndex, int skinId, string summonerName, string championName, float deathDurationRemaining, float timeSinceDeath, CreateHeroDeath heroDeath, bool unknown1, bool unknown2) : base(PacketCmd.S2CCreateHero, netId)
        {
            _netId = netId;
            _clientId = clientId;
            _netNodeId = netNodeId;
            _botSkillLevel = botSkillLevel;
            _isBlueTeam = isBlueTeam;
            _isBot = isBot;
            _botRank = botRank;
            _spawnPositionIndex = spawnPositionIndex;
            _skinId = skinId;
            _summonerName = summonerName;
            _championName = championName;
            _deathDurationRemaining = deathDurationRemaining;
            _timeSinceDeath = timeSinceDeath;
            _createHeroDeath = heroDeath;
            _unknown1 = unknown1;
            _unknown2 = unknown2;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteUInt(_netId);
            WriteInt(_clientId);
            WriteByte(_netNodeId);
            WriteByte((byte)_botSkillLevel);

            byte teamIdBitfield = 0;
            if (_isBlueTeam)
                teamIdBitfield |= 0x01;
            if (_isBot)
                teamIdBitfield |= 0x02;
            WriteByte(teamIdBitfield);

            WriteByte(_botRank);
            WriteByte(_spawnPositionIndex);
            WriteInt(_skinId);
            WriteFixedString(_summonerName, 128);
            WriteFixedString(_championName, 40);
            WriteFloat(_deathDurationRemaining);
            WriteFloat(_timeSinceDeath);
            WriteUInt((uint)_createHeroDeath);

            byte bitfield = 0;
            if (_unknown1)
                bitfield |= 0x01;
            if (_unknown2)
                bitfield |= 0x02;
            WriteByte(bitfield);
        }
    }
}