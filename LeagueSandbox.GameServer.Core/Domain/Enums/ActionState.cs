using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum ActionState
    {
        CanAttack = 1 << 0,
        CanCast = 1 << 1,
        CanMove = 1 << 2,
        CanNotMove = 1 << 3,
        Stealthed = 1 << 4,
        RevealSpecificUnit = 1 << 5,
        Taunted = 1 << 6,
        Feared = 1 << 7,
        IsFleeing = 1 << 8,
        CanNotAttack = 1 << 9,
        IsAsleep = 1 << 10,
        IsNearSighted = 1 << 11,
        IsGhosted = 1 << 12,

        Charmed = 1 << 15,
        NoRender = 1 << 16,
        ForceRenderParticles = 1 << 17,

        Unknown = 1 << 23 // set to 1 by default, interferes with targetability
    }
}