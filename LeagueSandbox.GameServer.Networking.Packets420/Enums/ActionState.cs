using System;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    [Flags]
    public enum ActionState
    {
        CanAttack = 1,
        CanCast = 2,
        CanMove = 4,
        CanNotMove = 8,
        Stealthed = 16,
        RevealSpecificUnit = 32,
        Taunted = 64,
        Feared = 128,
        IsFleeing = 256,
        CanNotAttack = 512,
        IsAsleep = 1024,
        IsNearSighted = 2048,
        IsGhosted = 4096,
        Charmed = 8192,
        NoRender = 16384,
        ForceRenderParticles = 32768,
        Unknown = 65536
    }
}