using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal class DTOTranslationService : IDTOTranslationService
    {
        private readonly IEnumTranslationService _enumTranslationService;

        public DTOTranslationService(IEnumTranslationService enumTranslationService)
        {
            _enumTranslationService = enumTranslationService;
        }

        public PlayerLoadInfo TranslatePlayerLoadInfo(IPlayer player)
        {
            return new PlayerLoadInfo
            (
                player.SummonerId,
                player.SummonerLevel,
                _enumTranslationService.TranslateSummonerSpell(player.Summoner1),
                _enumTranslationService.TranslateSummonerSpell(player.Summoner2),
                0,
                _enumTranslationService.TranslateTeam(player.Champion.Team),
                "", //TODO: Bot
                "", //TODO: Bot
                _enumTranslationService.TranslateRank(player.Rank),
                0, //TODO: Bot
                0, //TODO: Bot
                player.Icon,
                player.BadgeAlly,
                player.BadgeEnemy
            );
        }
    }
}
