using System;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiHero : ObjAiBase, IObjAiHero
    {
        public ulong SummonerId { get; }
        public int ClientId { get; private set; }
        public bool IsBot { get; }
        public bool IsPlayerControlled { get; private set; }

        //PlayerScore
        //    ShopEnabled
        //ShopEnabled
        //    MultiKillDisplayCount
        public ObjAiHero(Team team, Vector3 position, IStats stats, uint netId, ulong summonerId, int clientId, bool isBot, bool isPlayerControlled, string skinName, int skinId, ISpellBook spellBook)
            : base(team, position, stats, netId, skinName, skinId, 1200, spellBook)
        {
            SummonerId = summonerId;
            ClientId = clientId;
            IsBot = isBot;
            IsPlayerControlled = isPlayerControlled;
        }

        public void EnablePlayerControl()
        {
            if (IsBot)
                throw new InvalidOperationException("Bots cannot be controlled by players");
            if (IsPlayerControlled)
                throw new InvalidOperationException($"Champion {NetId} is already player controlled");

            IsPlayerControlled = true;
        }
    }
}
