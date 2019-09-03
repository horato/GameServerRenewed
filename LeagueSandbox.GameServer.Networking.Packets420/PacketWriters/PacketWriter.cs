using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using LeagueSandbox.GameServer.Networking.Packets420.Services;
using Unity;
using SpellFlags = LeagueSandbox.GameServer.Networking.Packets420.Enums.SpellFlags;
using TipCommand = LeagueSandbox.GameServer.Core.Domain.Enums.TipCommand;

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
                new List<string>(), //TODO: mutators
                0, //TODO: mutators
                string.Empty, //TODO: ranked teams
                string.Empty, //TODO: ranked teams
                string.Empty, //TODO: ranked teams
                string.Empty, //TODO: ranked teams
                string.Empty, //TODO: metrics?
                string.Empty,
                0,
                string.Empty, //TODO: Dradis? I am curious
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                0,
                new TipConfig(), //TODO: Tip config
                GameFeatures.FoundryOptions | GameFeatures.EarlyWarningForFOWMissiles | GameFeatures.NewPlayerRecommendedPages | GameFeatures.HighlightLineMissileTargets | GameFeatures.ItemUndo,
                new List<uint>(), //TODO: disabled items support
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
            foreach (var player in players.OrderBy(x => x.Champion.ClientId))
            {
                switch (player.Champion.Team)
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
                        throw new ArgumentOutOfRangeException(nameof(player.Champion.Team), player.Champion.Team, null);
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

        public byte[] WriteStartSpawn(byte blueBotsCount, byte redBotsCount)
        {
            return new StartSpawn(blueBotsCount, redBotsCount).GetBytes();
        }

        public byte[] WriteCreateHero(IPlayer player)
        {
            return new CreateHero
            (
                player.Champion.NetId,
                player.Champion.ClientId,
                0x40,  //TODO net node id
                BotSkillLevel.Beginner,
                player.Champion.Team == Team.Blue,
                player.Champion.IsBot,
                0, //TODO: Bot
                0, //TODO: SpawnIndex
                player.Champion.SkinId,
                player.SummonerName,
                player.Champion.SkinName,
                0, //TODO Death
                0, //TODO Death
                CreateHeroDeath.Alive, //TODO Death
                false,  //TODO what are those
                false  //TODO what are those
            ).GetBytes();
        }

        public byte[] WriteAvatarInfo(IPlayer player)
        {
            return new AvatarInfo
            (
                player.Champion.NetId,
                new List<uint>(), // TODO: inventory
                new[] { _enumTranslationService.TranslateSummonerSpell(player.Champion.SummonerSpell1), _enumTranslationService.TranslateSummonerSpell(player.Champion.SummonerSpell2) },
                player.Runes.Select(x => checked(new Talent((uint)x.Key, (byte)x.Value))),
                checked((byte)player.SummonerLevel),
                0 // TODO: ward skin
            ).GetBytes();
        }

        public byte[] WriteEndSpawn()
        {
            return new EndSpawn().GetBytes();
        }

        public byte[] WriteStartGame(bool enablePause)
        {
            return new StartGame(enablePause).GetBytes();
        }

        public byte[] WriteCreateTurret(IObjAiTurret turret)
        {
            return new CreateTurret
            (
                turret.NetId,
                NetNodeID.Spawned,
                turret.SkinName,
                true,
                SpellFlags.TargetableToAll
            ).GetBytes();
        }

        public byte[] WriteAddRegion(IAttackableUnit unit, uint regionNetId)
        {
            return new AddRegion
            (
                _enumTranslationService.TranslateTeam(unit.Team),
                -2,
                unit is IObjAiHero hero ? hero.ClientId : 0,
                unit.NetId,
                regionNetId,
                0,
                unit.Position.ToVector2(),
                2500,
                88.4f,
                130,
                1.0f,
                0,
                true,
                true,
                true,
                unit.VisionRadius
            ).GetBytes();
        }

        public byte[] WriteSpawnLevelProp(ILevelPropAI levelProp)
        {
            return new SpawnLevelProp
            (
                levelProp.NetId,
                NetNodeID.Spawned,
                levelProp.SkinId,
                levelProp.Position,
                levelProp.FacingDirection,
                levelProp.PositionOffset,
                new Vector3(1, 1, 1),
                _enumTranslationService.TranslateTeam(levelProp.Team),
                0,
                0,
                LevelPropType.LevelPropGameobject,
                levelProp.Name,
                levelProp.SkinName
            ).GetBytes();
        }

        public byte[] WriteOnEnterVisibilityClient(IAttackableUnit unit)
        {
            var charStackDataList = new List<CharacterStackData> { CreateCharacterStackData(unit) };

            var buffCountList = new List<KeyValuePair<byte, int>>();
            if (unit is IObjAiBase)
            {
                //TODO: buff list
            }

            //TODO: Use MovementDataNormal instead, because currently we desync if the unit is moving
            // TODO: Save unit waypoints in unit class so they can be used here for MovementDataNormal
            var md = new MovementDataStop
            (
               0x0006E4CF, //TODO: generate real movement SyncId
               unit.Position.ToVector2(),
               new Vector2(0, 1)
            );

            return new OnEnterVisiblityClient
            (
                unit.NetId,
                new List<BasePacket>(),
                new List<ItemData>(),
                null,
                charStackDataList,
                0,
                0,
                new Vector3(1, 0, 0),
                buffCountList,
                false,
                md
            ).GetBytes();
        }

        private CharacterStackData CreateCharacterStackData(IAttackableUnit unit)
        {
            var skinName = string.Empty;
            var skinId = 0;
            if (unit is IObjAiBase aiBase)
            {
                skinName = aiBase.SkinName;
                skinId = aiBase.SkinId;
            }

            return new CharacterStackData(skinName, (uint)skinId, false, false, false, 0);
        }

        public byte[] WriteOnEnterLocalVisibilityClient(IAttackableUnit unit)
        {
            return new OnEnterLocalVisibilityClient
            (
                unit.NetId,
                new List<BasePacket>(),
                unit.Stats.HealthPoints.Total,
                unit.Stats.CurrentHealth
            ).GetBytes();
        }

        public byte[] WriteSynchSimTime(float simTime)
        {
            return new SynchSimTime(simTime).GetBytes();
        }

        public byte[] WriteSyncMissionTime(float missionTime)
        {
            return new SyncMissionStartTime(missionTime).GetBytes();
        }

        public byte[] WriteHandleTipUpdate(string tipHeader, string tipText, string tipImagePath, TipCommand tipCommand, uint tipId, uint targetNetId)
        {
            return new HandleTipUpdate
            (
                tipHeader,
                tipText,
                tipImagePath,
                _enumTranslationService.TranslateTipCommand(tipCommand),
                tipId,
                targetNetId
            ).GetBytes();
        }

        public byte[] WriteMapPing(Vector2 position, uint targetNetId, uint sourceNetId, PingCategory pingCategory, bool playAudio, bool showChat, bool pingThrottled, bool playVo)
        {
            return new MapPing
            (
                position,
                targetNetId,
                sourceNetId,
                _enumTranslationService.TranslatePingCategory(pingCategory),
                playAudio,
                showChat,
                pingThrottled,
                playVo
            ).GetBytes();
        }
    }
}
