using System;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using ActionState = LeagueSandbox.GameServer.Networking.Packets420.Enums.ActionState;
using MovementType = LeagueSandbox.GameServer.Core.Domain.Enums.MovementType;
using PrimaryAbilityResourceType = LeagueSandbox.GameServer.Networking.Packets420.Enums.PrimaryAbilityResourceType;
using SpellFlags = LeagueSandbox.GameServer.Networking.Packets420.Enums.SpellFlags;
using SpellSlot = LeagueSandbox.GameServer.Networking.Packets420.Enums.SpellSlot;
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

        public MovementType TranslateMovementOrderType(Enums.MovementType orderType)
        {
            switch (orderType)
            {
                case Enums.MovementType.Emote:
                    return MovementType.Emote;
                case Enums.MovementType.Move:
                    return MovementType.Move;
                case Enums.MovementType.Attack:
                    return MovementType.Attack;
                case Enums.MovementType.Attackmove:
                    return MovementType.Attackmove;
                case Enums.MovementType.Stop:
                    return MovementType.Stop;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderType), orderType, null);
            }
        }

        public uint TranslateSpellSlotForStatsUpdate(GameServer.Core.Domain.Enums.SpellSlot slot)
        {
            var result = 0u;
            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.Q))
            {
                result |= 1 << (int)SpellSlot.Spell1;
            }

            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.W))
            {
                result |= 1 << (int)SpellSlot.Spell2;
            }

            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.E))
            {
                result |= 1 << (int)SpellSlot.Spell3;
            }

            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.R))
            {
                result |= 1 << (int)SpellSlot.Ultimate;
            }

            return result;
        }

        public uint TranslateSpellSlotSummonerForStatsUpdate(GameServer.Core.Domain.Enums.SpellSlot slot)
        {
            var result = 0u;
            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.D))
            {
                result |= 1 << (int)SpellSlot.Summoner1;
            }

            if (slot.HasFlag(GameServer.Core.Domain.Enums.SpellSlot.F))
            {
                result |= 1 << (int)SpellSlot.Summoner2;
            }

            return result;
        }

        public SpellFlags TranslateSpellFlags(GameServer.Core.Domain.Enums.SpellFlags flags)
        {
            var result = default(SpellFlags);
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AutoCast))
                result |= SpellFlags.AutoCast;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.InstantCast))
                result |= SpellFlags.InstantCast;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.PersistThroughDeath))
                result |= SpellFlags.PersistThroughDeath;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NonDispellable))
                result |= SpellFlags.NonDispellable;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NoClick))
                result |= SpellFlags.NoClick;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectImportantBotTargets))
                result |= SpellFlags.AffectImportantBotTargets;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AllowWhileTaunted))
                result |= SpellFlags.AllowWhileTaunted;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NotAffectZombie))
                result |= SpellFlags.NotAffectZombie;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectUntargetable))
                result |= SpellFlags.AffectUntargetable;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectEnemies))
                result |= SpellFlags.AffectEnemies;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectFriends))
                result |= SpellFlags.AffectFriends;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectNeutral))
                result |= SpellFlags.AffectNeutral;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectAllSides))
                result |= SpellFlags.AffectAllSides;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectBuildings))
                result |= SpellFlags.AffectBuildings;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectMinions))
                result |= SpellFlags.AffectMinions;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectHeroes))
                result |= SpellFlags.AffectHeroes;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectTurrets))
                result |= SpellFlags.AffectTurrets;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectAllUnitTypes))
                result |= SpellFlags.AffectAllUnitTypes;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NotAffectSelf))
                result |= SpellFlags.NotAffectSelf;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AlwaysSelf))
                result |= SpellFlags.AlwaysSelf;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectDead))
                result |= SpellFlags.AffectDead;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectNotPet))
                result |= SpellFlags.AffectNotPet;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectBarracksOnly))
                result |= SpellFlags.AffectBarracksOnly;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.IgnoreVisibilityCheck))
                result |= SpellFlags.IgnoreVisibilityCheck;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NonTargetableAlly))
                result |= SpellFlags.NonTargetableAlly;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NonTargetableEnemy))
                result |= SpellFlags.NonTargetableEnemy;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.TargetableToAll))
                result |= SpellFlags.TargetableToAll;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.NonTargetableAll))
                result |= SpellFlags.NonTargetableAll;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectWards))
                result |= SpellFlags.AffectWards;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.AffectUseable))
                result |= SpellFlags.AffectUseable;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.IgnoreAllyMinion))
                result |= SpellFlags.IgnoreAllyMinion;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.IgnoreEnemyMinion))
                result |= SpellFlags.IgnoreEnemyMinion;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.IgnoreLaneMinion))
                result |= SpellFlags.IgnoreLaneMinion;
            if (flags.HasFlag(GameServer.Core.Domain.Enums.SpellFlags.IgnoreClones))
                result |= SpellFlags.IgnoreClones;

            return result;
        }

        public ActionState TranslateActionState(GameServer.Core.Domain.Enums.ActionState actionState)
        {
            var result = default(ActionState);
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.CanAttack))
                result |= ActionState.CanAttack;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.CanCast))
                result |= ActionState.CanCast;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.CanMove))
                result |= ActionState.CanMove;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.CanNotMove))
                result |= ActionState.CanNotMove;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.Stealthed))
                result |= ActionState.Stealthed;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.RevealSpecificUnit))
                result |= ActionState.RevealSpecificUnit;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.Taunted))
                result |= ActionState.Taunted;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.Feared))
                result |= ActionState.Feared;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.IsFleeing))
                result |= ActionState.IsFleeing;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.CanNotAttack))
                result |= ActionState.CanNotAttack;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.IsAsleep))
                result |= ActionState.IsAsleep;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.IsNearSighted))
                result |= ActionState.IsNearSighted;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.IsGhosted))
                result |= ActionState.IsGhosted;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.Charmed))
                result |= ActionState.Charmed;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.NoRender))
                result |= ActionState.NoRender;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.ForceRenderParticles))
                result |= ActionState.ForceRenderParticles;
            if (actionState.HasFlag(GameServer.Core.Domain.Enums.ActionState.Unknown))
                result |= ActionState.Unknown;

            return result;
        }

        public PrimaryAbilityResourceType TranslateParType(GameServer.Core.Domain.Enums.PrimaryAbilityResourceType parType)
        {
            switch (parType)
            {
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Mana:
                    return PrimaryAbilityResourceType.Mana;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Energy:
                    return PrimaryAbilityResourceType.Energy;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.None:
                    return PrimaryAbilityResourceType.None;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Shield:
                    return PrimaryAbilityResourceType.Shield;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.BattleFury:
                    return PrimaryAbilityResourceType.BattleFury;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.DragonFury:
                    return PrimaryAbilityResourceType.DragonFury;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Rage:
                    return PrimaryAbilityResourceType.Rage;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Heat:
                    return PrimaryAbilityResourceType.Heat;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Ferocity:
                    return PrimaryAbilityResourceType.Ferocity;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.BloodWell:
                    return PrimaryAbilityResourceType.BloodWell;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Wind:
                    return PrimaryAbilityResourceType.Wind;
                case GameServer.Core.Domain.Enums.PrimaryAbilityResourceType.Other:
                    return PrimaryAbilityResourceType.Other;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parType), parType, null);
            }
        }

        public SpellSlot TranslateSpellSlot(GameServer.Core.Domain.Enums.SpellSlot spellSlot)
        {
            switch(spellSlot)
            {
                case GameServer.Core.Domain.Enums.SpellSlot.Q:
                    return SpellSlot.Spell1;
                case GameServer.Core.Domain.Enums.SpellSlot.W:
                    return SpellSlot.Spell2;
                case GameServer.Core.Domain.Enums.SpellSlot.E:
                    return SpellSlot.Spell3;
                case GameServer.Core.Domain.Enums.SpellSlot.R:
                    return SpellSlot.Ultimate;
                case GameServer.Core.Domain.Enums.SpellSlot.D:
                    return SpellSlot.Summoner1;
                case GameServer.Core.Domain.Enums.SpellSlot.F:
                    return SpellSlot.Summoner2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spellSlot), spellSlot, null);
            }
        }

        public GameServer.Core.Domain.Enums.SpellSlot TranslateSpellSlot(SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Spell1:
                    return GameServer.Core.Domain.Enums.SpellSlot.Q;
                case SpellSlot.Spell2:
                    return GameServer.Core.Domain.Enums.SpellSlot.W;
                case SpellSlot.Spell3:
                    return GameServer.Core.Domain.Enums.SpellSlot.E;
                case SpellSlot.Ultimate:
                    return GameServer.Core.Domain.Enums.SpellSlot.R;
                case SpellSlot.Summoner1:
                    return GameServer.Core.Domain.Enums.SpellSlot.D;
                case SpellSlot.Summoner2:
                    return GameServer.Core.Domain.Enums.SpellSlot.F;
                case SpellSlot.Trinket:
                case SpellSlot.BluePill:
                case SpellSlot.ExtraItem2:
                case SpellSlot.TemporaryItemSlotStart:
                case SpellSlot.Respawn:
                case SpellSlot.Use:
                case SpellSlot.Passive:
                case SpellSlot.Slotless:
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }
        }
    }
}
