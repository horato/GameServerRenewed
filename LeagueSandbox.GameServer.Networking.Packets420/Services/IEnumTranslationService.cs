using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using ActionState = LeagueSandbox.GameServer.Networking.Packets420.Enums.ActionState;
using ChatType = LeagueSandbox.GameServer.Core.Domain.Enums.ChatType;
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
        TeamId TranslateTeam(Team team);
        string TranslateRank(Rank rank);
        TipCommand TranslateTipCommand(GameServer.Core.Domain.Enums.TipCommand tipCommand);
        PingCategory TranslatePingCategory(Pings category);
        Pings TranslatePingCategory(PingCategory category);
        MovementType TranslateMovementOrderType(Enums.MovementType orderType);
        uint TranslateSpellSlotForStatsUpdate(GameServer.Core.Domain.Enums.SpellSlot slot);
        uint TranslateSpellSlotSummonerForStatsUpdate(GameServer.Core.Domain.Enums.SpellSlot spellSlot);
        SpellFlags TranslateSpellFlags(GameServer.Core.Domain.Enums.SpellFlags flags);
        ActionState TranslateActionState(GameServer.Core.Domain.Enums.ActionState actionState);
        PrimaryAbilityResourceType TranslateParType(GameServer.Core.Domain.Enums.PrimaryAbilityResourceType parType);
        SpellSlot TranslateSpellSlot(GameServer.Core.Domain.Enums.SpellSlot spellSlot);
        GameServer.Core.Domain.Enums.SpellSlot TranslateSpellSlot(SpellSlot requestSlot);
        ChatType TranslateChatType(Enums.ChatType chatType);
        Enums.ChatType TranslateChatType(ChatType chatType);
        Enums.DamageResultType TranslateDamageResultType(GameServer.Core.Domain.Enums.DamageResultType damageResultType);
        Enums.DamageType TranslateDamageType(GameServer.Core.Domain.Enums.DamageType damageType);
    }
}