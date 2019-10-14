using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{    
    /// <summary> Do not change. Used in json. </summary>
    [Flags]
    public enum SpellFlags : ulong
    {
        AutoCast = 2,
        InstantCast = 4,
        PersistThroughDeath = 8,
        NonDispellable = 16,
        NoClick = 32,
        AffectImportantBotTargets = 64,
        AllowWhileTaunted = 128,
        NotAffectZombie = 256,
        AffectUntargetable = 512,
        AffectEnemies = 1024,
        AffectFriends = 2045,
        AffectNeutral = 4096,
        AffectAllSides = 8192,
        AffectBuildings = 16384,
        AffectMinions = 32768,
        AffectHeroes = 65536,
        AffectTurrets = 131072,
        AffectAllUnitTypes = 262144,
        NotAffectSelf = 524288,
        AlwaysSelf = 1048576,
        AffectDead = 2097152,
        AffectNotPet = 4194304,
        AffectBarracksOnly = 8388608,
        IgnoreVisibilityCheck = 16777216,
        NonTargetableAlly = 33554432,
        NonTargetableEnemy = 67108864,
        TargetableToAll = 134217728,
        NonTargetableAll = 268435456,
        AffectWards = 536870912,
        AffectUseable = 1073741824,
        IgnoreAllyMinion = 2147483648,
        IgnoreEnemyMinion = 4294967296,
        IgnoreLaneMinion = 8589934592,
        IgnoreClones = 17179869184,
    }
}
