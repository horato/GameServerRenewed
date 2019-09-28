using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    public class CastInfo
    {
        public uint SpellHash { get; }
        public uint SpellNetID { get; }
        public byte SpellLevel { get; }
        public float AttackSpeedModifier { get; }
        public uint CasterNetID { get; }
        public uint SpellChainOwnerNetID { get; }
        public uint PackageHash { get; }
        public uint MissileNetID { get; }
        public Vector3 TargetPosition { get; }
        public Vector3 TargetPositionEnd { get; }
        public List<Target> Targets { get; } = new List<Target>();
        public float DesignerCastTime { get; }
        public float ExtraCastTime { get; }
        public float DesignerTotalTime { get; }
        public float Cooldown { get; }
        public float StartCastTime { get; }
        public bool IsAutoAttack { get; }
        public bool IsSecondAutoAttack { get; }
        public bool IsForceCastingOrChannel { get; }
        public bool IsOverrideCastPosition { get; }
        public bool IsClickCasted { get; }
        public byte SpellSlot { get; }
        public float ManaCost { get; }
        public Vector3 SpellCastLaunchPosition { get; }
        public int AmmoUsed { get; }
        public float AmmoRechargeTime { get; }

        public CastInfo(uint spellHash, uint spellNetId, byte spellLevel, float attackSpeedModifier, uint casterNetId, uint spellChainOwnerNetId, uint packageHash, uint missileNetId, Vector3 targetPosition, Vector3 targetPositionEnd, float designerCastTime, float extraCastTime, float designerTotalTime, float cooldown, float startCastTime, bool isAutoAttack, bool isSecondAutoAttack, bool isForceCastingOrChannel, bool isOverrideCastPosition, bool isClickCasted, byte spellSlot, float manaCost, Vector3 spellCastLaunchPosition, int ammoUsed, float ammoRechargeTime)
        {
            SpellHash = spellHash;
            SpellNetID = spellNetId;
            SpellLevel = spellLevel;
            AttackSpeedModifier = attackSpeedModifier;
            CasterNetID = casterNetId;
            SpellChainOwnerNetID = spellChainOwnerNetId;
            PackageHash = packageHash;
            MissileNetID = missileNetId;
            TargetPosition = targetPosition;
            TargetPositionEnd = targetPositionEnd;
            DesignerCastTime = designerCastTime;
            ExtraCastTime = extraCastTime;
            DesignerTotalTime = designerTotalTime;
            Cooldown = cooldown;
            StartCastTime = startCastTime;
            IsAutoAttack = isAutoAttack;
            IsSecondAutoAttack = isSecondAutoAttack;
            IsForceCastingOrChannel = isForceCastingOrChannel;
            IsOverrideCastPosition = isOverrideCastPosition;
            IsClickCasted = isClickCasted;
            SpellSlot = spellSlot;
            ManaCost = manaCost;
            SpellCastLaunchPosition = spellCastLaunchPosition;
            AmmoUsed = ammoUsed;
            AmmoRechargeTime = ammoRechargeTime;
        }
    }

    public static class CastInfoExtension
    {
        public static void WriteCastInfo(this BinaryWriter writerOrg, CastInfo data)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write((uint)data.SpellHash);
                writer.Write((uint)data.SpellNetID);
                writer.Write((byte)data.SpellLevel);
                writer.Write((float)data.AttackSpeedModifier);
                writer.Write((uint)data.CasterNetID);
                writer.Write((uint)data.SpellChainOwnerNetID);
                writer.Write((uint)data.PackageHash);
                writer.Write((uint)data.MissileNetID);
                writer.Write((float)data.TargetPosition.X);
                writer.Write((float)data.TargetPosition.Y);
                writer.Write((float)data.TargetPosition.Z);
                writer.Write((float)data.TargetPositionEnd.X);
                writer.Write((float)data.TargetPositionEnd.Y);
                writer.Write((float)data.TargetPositionEnd.Z);

                var targetCount = data.Targets.Count;
                if (targetCount > 32)
                {
                    throw new IOException("CastInfo targets > 32!!!");
                }
                writer.Write((byte)targetCount);
                foreach (var target in data.Targets)
                {
                    writer.Write((uint)target.UnitNetID);
                    writer.Write((byte)target.HitResult);
                }

                writer.Write((float)data.DesignerCastTime);
                writer.Write((float)data.ExtraCastTime);
                writer.Write((float)data.DesignerTotalTime);
                writer.Write((float)data.Cooldown);
                writer.Write((float)data.StartCastTime);

                byte bitfield = 0;
                if (data.IsAutoAttack)
                {
                    bitfield |= 1;
                }
                if (data.IsSecondAutoAttack)
                {
                    bitfield |= 2;
                }
                if (data.IsForceCastingOrChannel)
                {
                    bitfield |= 4;
                }
                if (data.IsOverrideCastPosition)
                {
                    bitfield |= 8;
                }
                if (data.IsClickCasted)
                {
                    bitfield |= 16;
                }
                writer.Write((byte)bitfield);

                writer.Write((byte)data.SpellSlot);
                writer.Write((float)data.ManaCost);
                writer.Write((float)data.SpellCastLaunchPosition.X);
                writer.Write((float)data.SpellCastLaunchPosition.Y);
                writer.Write((float)data.SpellCastLaunchPosition.Z);
                writer.Write((int)data.AmmoUsed);
                writer.Write((float)data.AmmoRechargeTime);

                var buffer = stream.ToArray();
                writerOrg.Write((ushort)(buffer.Length + 2));
                writerOrg.Write(buffer);
            }
        }
    }
}
