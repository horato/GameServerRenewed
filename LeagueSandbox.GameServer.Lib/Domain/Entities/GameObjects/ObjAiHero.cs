using System;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Data;
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
        public ObjAiHero(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, ISpellBook spellBook, ulong summonerId, int clientId, bool isBot, bool isPlayerControlled, ICharacterData characterData)
            : base(team, position, stats, netId, characterData.PerceptionBubbleRadius, characterData.GameplayCollisionRadius, skinName, skinId, spellBook, characterData)
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
