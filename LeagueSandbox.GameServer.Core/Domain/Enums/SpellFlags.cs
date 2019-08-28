using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum SpellFlags
    {
        AutoCast = 1,
        InstantCast = 2,
        PersistThroughDeath = 3,
        NonDispellable = 4,
        NoClick = 5,
        AffectImportantBotTargets = 6,
        AllowWhileTaunted = 7,
        NotAffectZombie = 8,
        AffectUntargetable = 9,
        AffectEnemies = 10,
        AffectFriends = 11,
        AffectNeutral = 12,
        AffectAllSides = 13,
        AffectBuildings = 14,
        AffectMinions = 15,
        AffectHeroes = 16,
        AffectTurrets = 17,
        AffectAllUnitTypes = 18,
        NotAffectSelf = 19,
        AlwaysSelf = 20,
        AffectDead = 21,
        AffectNotPet = 22,
        AffectBarracksOnly = 23,
        IgnoreVisibilityCheck = 24,
        NonTargetableAlly = 25,
        NonTargetableEnemy = 26,
        TargetableToAll = 27,
        NonTargetableAll = 28,
        AffectWards = 29,
        AffectUseable = 30,
        IgnoreAllyMinion = 31,
        IgnoreEnemyMinion = 32,
        IgnoreLaneMinion = 33,
        IgnoreClones = 34,
    }
}
