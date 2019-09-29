using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class CastSpellRequest : RequestDefinition
    {
        public uint NetId { get; }
        public SpellSlot Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        public bool IsHudClickCast { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 EndPosition { get; set; }
        public uint TargetNetID { get; set; }

        public CastSpellRequest(uint netId, SpellSlot slot, bool isSummonerSpellBook, bool isHudClickCast, Vector2 position, Vector2 endPosition, uint targetNetId)
        {
            NetId = netId;
            Slot = slot;
            IsSummonerSpellBook = isSummonerSpellBook;
            IsHudClickCast = isHudClickCast;
            Position = position;
            EndPosition = endPosition;
            TargetNetID = targetNetId;
        }
    }
}