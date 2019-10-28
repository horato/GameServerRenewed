using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class BasicAttackData
    {
        public uint TargetNetID { get; }
        public Vector3 TargetPosition { get; }
        public float ExtraTime { get; }
        public uint MissileNextID { get; }
        public BasicAttackSlot AttackSlot { get; }

        public BasicAttackData(uint targetNetId, Vector3 targetPosition, float extraTime, uint missileNextId, BasicAttackSlot attackSlot)
        {
            TargetNetID = targetNetId;
            TargetPosition = targetPosition;
            ExtraTime = extraTime;
            MissileNextID = missileNextId;
            AttackSlot = attackSlot;
        }
    }

    internal static class BasicAttackDataExtension
    {
        public static BasicAttackData ReadBasicAttackDataPacket(this BinaryReader reader)
        {
            var targetNetId = reader.ReadUInt32();
            var extraTime = (reader.ReadByte() - 128) / 100.0f;
            var missileNextId = reader.ReadUInt32();
            var attackSlot = (BasicAttackSlot)reader.ReadByte();
            var targetPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            return new BasicAttackData(targetNetId, targetPosition, extraTime, missileNextId, attackSlot);
        }

        public static void WriteBasicAttackDataPacket(this BinaryWriter writer, BasicAttackData attack)
        {
            writer.Write((uint)attack.TargetNetID);
            writer.Write((byte)((int)(attack.ExtraTime * 100.0f) + 128));
            writer.Write((uint)attack.MissileNextID);
            writer.Write((byte)attack.AttackSlot);
            writer.Write((float)attack.TargetPosition.X);
            writer.Write((float)attack.TargetPosition.Y);
            writer.Write((float)attack.TargetPosition.Z);
        }
    }
}
