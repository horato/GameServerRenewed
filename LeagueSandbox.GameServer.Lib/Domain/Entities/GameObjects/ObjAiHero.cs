using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiHero : ObjAiBase, IObjAiHero
    {
        public ulong SummonerId { get; }
        public int ClientId { get; }
        public bool IsBot { get; }
        public bool IsPlayerControlled { get; }

        //PlayerScore
        //    ShopEnabled
        //ShopEnabled
        //    MultiKillDisplayCount
        public ObjAiHero(Team team, Vector3 position, IStats stats, uint netId, ulong summonerId, int clientId, bool isBot, bool isPlayerControlled) : base(team, position, stats, netId)
        {
            SummonerId = summonerId;
            ClientId = clientId;
            IsBot = isBot;
            IsPlayerControlled = isPlayerControlled;
        }
    }
}
