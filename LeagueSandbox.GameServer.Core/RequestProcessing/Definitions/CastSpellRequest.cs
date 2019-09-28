using System.IO;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    internal class CastSpellRequest : RequestDefinition
    {
        public int NetId { get; }
        public byte SpellSlotType { get; }
        public byte SpellSlot { get; }
        public float X { get; }
        public float Y { get; }
        public float X2 { get; }
        public float Y2 { get; }
        public uint TargetNetId { get; }

        public CastSpellRequest(int netId, byte spellSlotType, byte spellSlot, float x, float y, float x2, float y2, uint targetNetId)
        {
            NetId = netId;
            SpellSlotType = spellSlotType;
            SpellSlot = spellSlot;
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
            TargetNetId = targetNetId;
        }
    }
}