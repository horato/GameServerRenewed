using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class ObjAiHeroBuilder : EntityBuilderBase<ObjAiHero>
    {
        private Team _team = Team.Blue;
        private Vector3 _position = new Vector3(11, 43, 2);
        private IStats _stats = new StatsBuilder().Build();
        private uint _netId = 2465355;

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

        public override ObjAiHero Build()
        {
            var instance = new ObjAiHero(_team, _position, _stats, _netId);

            return instance;
        }
    }
}
