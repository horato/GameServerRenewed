using System;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using TipCommand = LeagueSandbox.GameServer.Networking.Packets420.Enums.TipCommand;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal class EnumTranslationService : IEnumTranslationService
    {
        public MapId TranslateMapType(MapType type)
        {
            switch (type)
            {
                //case MapType.FlatTestMap:
                //    return MapId.FlatTestMap;
                case MapType.SummonersRift:
                    return MapId.SummonersRift;
                //case MapType.HarrowingRift:
                //    return MapId.HarrowingRift;
                //case MapType.ProvingGrounds:
                //    return MapId.ProvingGrounds;
                //case MapType.TwistedTreeline:
                //    return MapId.TwistedTreeline;
                //case MapType.WinterRift:
                //    return MapId.WinterRift;
                case MapType.CrystalScar:
                    return MapId.CrystalScar;
                case MapType.NewTwistedTreeline:
                    return MapId.NewTwistedTreeline;
                case MapType.NewSummonersRift:
                    return MapId.NewSummonersRift;
                case MapType.HowlingAbyss:
                    return MapId.HowlingAbyss;
                //case MapType.ButchersBridge:
                //    return MapId.ButchersBridge;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public SummonerSpellHash TranslateSummonerSpell(SummonerSpell spell)
        {
            switch (spell)
            {
                case SummonerSpell.Revive:
                    return SummonerSpellHash.Revive;
                case SummonerSpell.Smite:
                    return SummonerSpellHash.Smite;
                case SummonerSpell.Exhaust:
                    return SummonerSpellHash.Exhaust;
                case SummonerSpell.Barrier:
                    return SummonerSpellHash.Barrier;
                case SummonerSpell.Teleport:
                    return SummonerSpellHash.Teleport;
                case SummonerSpell.Ghost:
                    return SummonerSpellHash.Ghost;
                case SummonerSpell.Heal:
                    return SummonerSpellHash.Heal;
                case SummonerSpell.Cleanse:
                    return SummonerSpellHash.Cleanse;
                case SummonerSpell.Clarity:
                    return SummonerSpellHash.Clarity;
                case SummonerSpell.Ignite:
                    return SummonerSpellHash.Ignite;
                case SummonerSpell.Promote:
                    return SummonerSpellHash.Promote;
                case SummonerSpell.Clair:
                    return SummonerSpellHash.Clair;
                case SummonerSpell.Flash:
                    return SummonerSpellHash.Flash;
                case SummonerSpell.Test:
                    return SummonerSpellHash.Test;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spell), spell, null);
            }
        }

        public TeamId TranslateTeam(Team team)
        {
            switch (team)
            {
                case Team.Blue:
                    return TeamId.Blue;
                case Team.Red:
                    return TeamId.Purple;
                case Team.Neutral:
                    return TeamId.Neutral;
                default:
                    throw new ArgumentOutOfRangeException(nameof(team), team, null);
            }
        }

        public string TranslateRank(Rank rank)
        {
            switch (rank)
            {
                case Rank.Bronze:
                    return "BRONZE";
                case Rank.Silver:
                    return "SILVER";
                case Rank.Gold:
                    return "GOLD";
                case Rank.Platinum:
                    return "PLATINUM";
                case Rank.Diamond:
                    return "DIAMOND";
                case Rank.Challenger:
                    return "CHALLENGER";
                default:
                    throw new ArgumentOutOfRangeException(nameof(rank), rank, null);
            }
        }

        public TipCommand TranslateTipCommand(GameServer.Core.Domain.Enums.TipCommand tipCommand)
        {
            switch (tipCommand)
            {
                case GameServer.Core.Domain.Enums.TipCommand.ActivateTip:
                    return TipCommand.ActivateTip;
                case GameServer.Core.Domain.Enums.TipCommand.RemoveTip:
                    return TipCommand.RemoveTip;
                case GameServer.Core.Domain.Enums.TipCommand.EnableTipEvents:
                    return TipCommand.EnableTipEvents;
                case GameServer.Core.Domain.Enums.TipCommand.DisableTipEvents:
                    return TipCommand.DisableTipEvents;
                case GameServer.Core.Domain.Enums.TipCommand.ActivateTipDialogue:
                    return TipCommand.ActivateTipDialogue;
                case GameServer.Core.Domain.Enums.TipCommand.EnableTipDialogueEvents:
                    return TipCommand.EnableTipDialogueEvents;
                case GameServer.Core.Domain.Enums.TipCommand.DisableTipDialogueEvents:
                    return TipCommand.DisableTipDialogueEvents;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipCommand), tipCommand, null);
            }
        }

        public PingCategory TranslatePingCategory(Pings category)
        {
            switch (category)
            {
                case Pings.Default:
                    return PingCategory.Default;
                case Pings.Charge:
                    return PingCategory.Charge;
                case Pings.Danger:
                    return PingCategory.Danger;
                case Pings.Missing:
                    return PingCategory.Missing;
                case Pings.OnMyWay:
                    return PingCategory.OnMyWay;
                case Pings.GetBack:
                    return PingCategory.GetBack;
                case Pings.Assist:
                    return PingCategory.Assist;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        public Pings TranslatePingCategory(PingCategory category)
        {
            switch (category)
            {
                case PingCategory.Default:
                    return Pings.Default;
                case PingCategory.Charge:
                    return Pings.Charge;
                case PingCategory.Danger:
                    return Pings.Danger;
                case PingCategory.Missing:
                    return Pings.Missing;
                case PingCategory.OnMyWay:
                    return Pings.OnMyWay;
                case PingCategory.GetBack:
                    return Pings.GetBack;
                case PingCategory.Assist:
                    return Pings.Assist;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }
    }
}
