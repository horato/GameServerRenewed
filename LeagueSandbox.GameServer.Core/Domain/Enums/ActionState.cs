using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum ActionState
    {
        CanAttack = 1,
        CanCast = 2,
        CanMove = 3,
        CanNotMove = 4,
        Stealthed = 5,
        RevealSpecificUnit = 6,
        Taunted = 6,
        Feared = 7,
        IsFleeing = 8,
        CanNotAttack = 9,
        IsAsleep = 10,
        IsNearSighted = 11,
        IsGhosted = 12,
        Charmed = 13,
        NoRender = 14,
        ForceRenderParticles = 15,
        Unknown = 16
    }
}