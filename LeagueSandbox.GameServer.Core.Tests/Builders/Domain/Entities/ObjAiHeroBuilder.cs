using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class ObjAiHeroBuilder : EntityBuilderBase<ObjAiHero>
    {
        private Team _team = Team.Blue;
        private Vector3 _position = new Vector3(11, 43, 2);
        private IStats _stats = new StatsBuilder().Build();
        private uint _netId = 2465355;
        private ulong _summonerId = 5415412;
        private int _clientId = 52;
        private bool _isBot = true;
        private bool _isPlayerControlled = true;
        private string _skinName = "Ahri";
        private int _skinId = 3;
        private ISpellBook _spellBook = new SpellBookBuilder().Build();
        private ICharacterData _characterData; //TODO: builder?

        public ObjAiHeroBuilder WithTeam(Team team)
        {
            _team = team;
            return this;
        }

        public ObjAiHeroBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ObjAiHeroBuilder WithStats(IStats stats)
        {
            _stats = stats;
            return this;
        }

        public ObjAiHeroBuilder WithNetId(uint netId)
        {
            _netId = netId;
            return this;
        }

        public ObjAiHeroBuilder WithSummonerId(ulong summonerId)
        {
            _summonerId = summonerId;
            return this;
        }

        public ObjAiHeroBuilder WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }

        public ObjAiHeroBuilder WithIsBot(bool isBot)
        {
            _isBot = isBot;
            return this;
        }

        public ObjAiHeroBuilder WithIsPlayerControlled(bool isPlayerControlled)
        {
            _isPlayerControlled = isPlayerControlled;
            return this;
        }

        public ObjAiHeroBuilder WithSkinName(string skinName)
        {
            _skinName = skinName;
            return this;
        }

        public ObjAiHeroBuilder WithSkinId(int skinId)
        {
            _skinId = skinId;
            return this;
        }

        public ObjAiHeroBuilder WithCharacterData(ICharacterData characterData)
        {
            _characterData = characterData;
            return this;
        }

        public override ObjAiHero Build()
        {
            var instance = new ObjAiHero(_team, _position, _stats, _netId, _skinName, _skinId, _spellBook, _summonerId, _clientId, _isBot, _isPlayerControlled, _characterData);

            return instance;
        }
    }
}
