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
    internal interface IEnumTranslationService
    {
        MapId TranslateMapType(MapType type);
        SummonerSpellHash TranslateSummonerSpell(SummonerSpell spell);
        TeamId TranslateTeam(Team team);
        string TranslateRank(Rank rank);
        TipCommand TranslateTipCommand(GameServer.Core.Domain.Enums.TipCommand tipCommand);
        PingCategory TranslatePingCategory(Pings category);
        Pings TranslatePingCategory(PingCategory category);
        MovementType TranslateMovementOrderType(Enums.MovementType orderType);
        SpellSlot TranslateSpellSlotClassic(GameServer.Core.Domain.Enums.SpellSlot spellSlot);
        SummonerSpellId TranslateSpellSlotSummoner(GameServer.Core.Domain.Enums.SpellSlot spellSlot);
        SpellFlags TranslateSpellFlags(GameServer.Core.Domain.Enums.SpellFlags flags);
        ActionState TranslateActionState(GameServer.Core.Domain.Enums.ActionState actionState);
        PrimaryAbilityResourceType TranslateParType(GameServer.Core.Domain.Enums.PrimaryAbilityResourceType parType);
    }
}