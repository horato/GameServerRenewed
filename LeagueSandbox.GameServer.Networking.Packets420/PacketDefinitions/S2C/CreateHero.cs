using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class CreateHero : BasePacket
    {
        private uint _netId;
        private int _clientId;
        private byte _netNodeId;
        private BotSkillLevel _botSkillLevel;
        private bool _isBlueTeam;
        private bool _isBot;
        private byte _botRank;
        private byte _spawnPositionIndex;
        private int _skinId;
        private string _name;
        private string _skin;
        private float _deathDurationRemaining;
        private float _timeSinceDeath;
        private CreateHeroDeath _createHeroDeath;
        private bool _unknown1; // something with scripts
        private bool _unknown2; // something with spawn

        public CreateHero(uint netId, int clientId, byte netNodeId, BotSkillLevel botSkillLevel, bool isBlueTeam, bool isBot, byte botRank, byte spawnPositionIndex, int skinId, float deathDurationRemaining, float timeSinceDeath, CreateHeroDeath heroDeath, bool unknown1, bool unknown2) : base(PacketCmd.S2CCreateHero)
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
            WriteFixedString(_name, 128);
            WriteFixedString(_skin, 40);
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