using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum SpellFlags : ulong
    {
        AutoCast = 1,
        InstantCast = 2,
        PersistThroughDeath = 4,
        NonDispellable = 8,
        NoClick = 16,
        AffectImportantBotTargets = 32,
        AllowWhileTaunted = 64,
        NotAffectZombie = 128,
        AffectUntargetable = 256,
        AffectEnemies = 512,
        AffectFriends = 1024,
        AffectNeutral = 2048,
        AffectAllSides = 4096,
        AffectBuildings = 8192,
        AffectMinions = 16384,
        AffectHeroes = 32768,
        AffectTurrets = 65536,
        AffectAllUnitTypes = 131072,
        NotAffectSelf = 262144,
        AlwaysSelf = 524288,
        AffectDead = 1048576,
        AffectNotPet = 2097152,
        AffectBarracksOnly = 4194304,
        IgnoreVisibilityCheck = 8388608,
        NonTargetableAlly = 16777216,
        NonTargetableEnemy = 33554432,
        TargetableToAll = 67108864,
        NonTargetableAll = 134217728,
        AffectWards = 268435456,
        AffectUseable = 536870912,
        IgnoreAllyMinion = 1073741824,
        IgnoreEnemyMinion = 2147483648,
        IgnoreLaneMinion = 4294967296,
        IgnoreClones = 8589934592,
    }
}
