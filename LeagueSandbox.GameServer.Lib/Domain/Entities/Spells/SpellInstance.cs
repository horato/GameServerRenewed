using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class SpellInstance : ISpellInstance
    {
        public ISpell Definition { get; }
        public SpellInstanceState State { get; private set; }
        public float CastTimeRemaining { get; private set; }
        public float ChannelTimeRemaining { get; private set; }
        public Vector2 TargetPosition { get; }
        public Vector2 TargetEndPosition { get; }
        public IAttackableUnit Target { get; }
        public uint FutureProjectileNetId { get; }
        public uint InstanceNetId { get; }
        public float ActualManaCost { get; }

        public SpellInstance(ISpell definition, SpellInstanceState state, float castTimeRemaining, float channelTimeRemaining, Vector2 targetPosition, Vector2 targetEndPosition, IAttackableUnit targetUnit, uint futureProjectileNetId, uint instanceNetId, float actualManaCost)
        {
            Definition = definition;
            State = state;
            CastTimeRemaining = castTimeRemaining;
            ChannelTimeRemaining = channelTimeRemaining;
            TargetPosition = targetPosition;
            TargetEndPosition = targetEndPosition;
            Target = targetUnit;
            FutureProjectileNetId = futureProjectileNetId;
            InstanceNetId = instanceNetId;
            ActualManaCost = actualManaCost;
        }

        public void CastingStart()
        {
            if (State != SpellInstanceState.PreparingToCast)
                throw new InvalidOperationException("Spell cannot start. Invalid state.");

            CastTimeRemaining = Definition.SpellData.SpellCastTime;
            State = SpellInstanceState.Casting;
        }

        public void CastingProgress(float secondsDiff)
        {
            if (State != SpellInstanceState.Casting)
                throw new InvalidOperationException("Invalid state. Cannot progress cast.");
            if (secondsDiff < 0)
                throw new InvalidOperationException("Diff must be greater or equal to 0");

            if (CastTimeRemaining > secondsDiff)
                CastTimeRemaining -= secondsDiff;
            else
                CastTimeRemaining = 0;
        }

        public void ChannelingStart()
        {
            if (State != SpellInstanceState.Casting)
                throw new InvalidOperationException("Channel cannot start. Invalid state.");

            ChannelTimeRemaining = Definition.ChannelDuration;
            State = SpellInstanceState.Channeling;
        }

        public void ChannelingProgress(float secondsDiff)
        {
            if (State != SpellInstanceState.Channeling)
                throw new InvalidOperationException("Invalid state. Cannot progress channel.");
            if (secondsDiff < 0)
                throw new InvalidOperationException("Diff must be greater or equal to 0");

            if (ChannelTimeRemaining > secondsDiff)
                ChannelTimeRemaining -= secondsDiff;
            else
                ChannelTimeRemaining = 0;
        }

        public void CastingFinished()
        {
            if (State != SpellInstanceState.Casting && State != SpellInstanceState.Channeling)
                throw new InvalidOperationException("Invalid state. Cannot finish cast.");

            CastTimeRemaining = 0;
            ChannelTimeRemaining = 0;
            State = SpellInstanceState.Finished;
        }
    }
}
