using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using LeagueSandbox.GameServer.Networking.Packets420.Services;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketWriters
{
    public class PacketWriter : IPacketWriter
    {
        private readonly IEnumTranslationService _enumTranslationService;
        private readonly IDTOTranslationService _dtoTranslationService;

        public PacketWriter(IUnityContainer unityContainer)
        {
            _enumTranslationService = unityContainer.Resolve<IEnumTranslationService>();
            _dtoTranslationService = unityContainer.Resolve<IDTOTranslationService>();
        }

        public byte[] WriteKeyCheckResponse(ulong summonerId, int clientId, uint versionNo, ulong checkId)
        {
            return new KeyCheckResponse(summonerId, clientId, versionNo, checkId).GetBytes();
        }

        public byte[] WriteNotifyQueryStatus()
        {
            return new QueryStatus().GetBytes();
        }

        public byte[] WriteSynchVersion(bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version)
        {
            return new SynchVersionResponse
            (
                versionMatches,
                false,
                false,
                false,
                _enumTranslationService.TranslateMapType(mapId),
                players.Select(x => _dtoTranslationService.TranslatePlayerLoadInfo(x)),
                version,
                "CLASSIC", //TODO: enum
                "NA1", // TODO: enum
                new List<string>(),
                0,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                0,
                new TipConfig(),
                GameFeatures.FoundryOptions | GameFeatures.EarlyWarningForFOWMissiles | GameFeatures.NewPlayerRecommendedPages | GameFeatures.HighlightLineMissileTargets | GameFeatures.ItemUndo,
                //487826,
                new List<uint>(),
                new List<bool>()
            ).GetBytes();
        }

        public byte[] WritePingLoadInfo(uint netId, int clientId, ulong summonerId, float loadedPercent, float eta, ushort count, ushort ping, bool isReady)
        {
            return new PingLoadInfoResponse(netId, clientId, summonerId, loadedPercent, eta, count, ping, isReady).GetBytes();
        }

        public byte[] WriteTeamRosterUpdate(IEnumerable<IPlayer> players)
        {
            var bluePlayers = new List<ulong>();
            var redPlayers = new List<ulong>();
            var connectedBluePlayers = 0u;
            var connectedRedPlayers = 0u;
            foreach (var player in players)
            {
                switch (player.Team)
                {
                    case Team.Blue:
                        bluePlayers.Add(player.SummonerId);
                        if (player.Champion.IsPlayerControlled)
                            connectedBluePlayers++;

                        break;
                    case Team.Red:
                        redPlayers.Add(player.SummonerId);
                        if (player.Champion.IsPlayerControlled)
                            connectedRedPlayers++;

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(player.Team), player.Team, null);
                }
            }

            return new TeamRosterUpdate(bluePlayers, redPlayers, connectedBluePlayers, connectedRedPlayers).GetBytes();
        }

        public byte[] WriteRename(ulong summonerId, int skinId, string playerName)
        {
            return new RenameResponse(summonerId, skinId, playerName).GetBytes();
        }

        public byte[] WriteReskin(ulong summonerId, int skinId, string skinName)
        {
            return new ReskinResponse(summonerId, skinId, skinName).GetBytes();
        }
    }
}
