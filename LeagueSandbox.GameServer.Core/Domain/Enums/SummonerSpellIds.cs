using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    /*
        SummonerSmiteAoE, Blasting Smite"
        SummonerSmiteDuel, Challenging Smite"
        SummonerSmitePlayerDuelist, Smite of Fury"
        SummonerSmitePlayerGanker, Chilling Smite"
        SummonerSmiteQuick, Scavenging Smite"
    */
    public enum SummonerSpell
    {
        Revive = 1,
        Smite = 2,
        Exhaust = 3,
        Barrier = 4,
        Teleport = 5,
        Ghost = 6,
        Heal = 7,
        Cleanse = 8,
        Clarity = 9,
        Ignite = 10,
        Promote = 11,
        Clair = 12,
        Flash = 13,

        // This has icon but no spell json
        Garrison = 15,

        // These are missing icon
        Surge = 14,
        Sabotage = 16,
        PromoteOdin = 17,
        Rally = 18,
    }

    public static class SummonerSpellExtensions
    {
        public static string ToSpellName(this SummonerSpell spell)
        {
            switch (spell)
            {
                case SummonerSpell.Revive:
                    return "SummonerRevive";
                case SummonerSpell.Smite:
                    return "SummonerSmite";
                case SummonerSpell.Exhaust:
                    return "SummonerExhaust";
                case SummonerSpell.Barrier:
                    return "SummonerBarrier";
                case SummonerSpell.Teleport:
                    return "SummonerTeleport";
                case SummonerSpell.Ghost:
                    return "SummonerHaste";
                case SummonerSpell.Heal:
                    return "SummonerHeal";
                case SummonerSpell.Cleanse:
                    return "SummonerBoost";
                case SummonerSpell.Clarity:
                    return "SummonerMana";
                case SummonerSpell.Ignite:
                    return "SummonerDot";
                case SummonerSpell.Promote:
                    return "SummonerPromoteSR";
                case SummonerSpell.Clair:
                    return "SummonerClairvoyance";
                case SummonerSpell.Flash:
                    return "SummonerFlash";
                case SummonerSpell.Surge:
                    return "SummonerBattleCry";
                case SummonerSpell.Rally:
                    return "SummonerRally";
                case SummonerSpell.Garrison:
                    return "SummonerOdinGarrison";
                case SummonerSpell.Sabotage:
                    return "SummonerOdinSabotage";
                case SummonerSpell.PromoteOdin:
                    return "SummonerOdinPromote";
                default:
                    throw new ArgumentOutOfRangeException(nameof(spell), spell, null);
            }
        }
    }
}