using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SynchVersionResponse : BasePacket
    {
        public bool VersionMatches { get; }
        public bool WriteToClientFile { get; }
        public bool MatchedGame { get; }
        public bool DradisInit { get; }

        public MapId MapToLoad { get; }
        public IList<PlayerLoadInfo> PlayerInfo { get; }
        public string VersionString { get; }
        public string MapMode { get; }
        public string PlatformID { get; }
        public IList<string> Mutators { get; }
        public byte MutatorsNum { get; }
        public string OrderRankedTeamName { get; }
        public string OrderRankedTeamTag { get; }
        public string ChaosRankedTeamName { get; }
        public string ChaosRankedTeamTag { get; }
        public string MetricsServerWebAddress { get; }
        public string MetricsServerWebPath { get; }
        public ushort MetricsServerPort { get; }
        public string DradisProdAddress { get; }
        public string DradisProdResource { get; }
        public ushort DradisProdPort { get; }
        public string DradisTestAddress { get; }
        public string DradisTestResource { get; }
        public ushort DradisTestPort { get; }
        public TipConfig TipConfig { get; }
        public ulong GameFeatures { get; }
        public IList<uint> DisabledItems { get; }
        public IList<bool> EnabledDradisMessages { get; }

        public SynchVersionResponse(bool versionMatches, bool writeToClientFile, bool matchedGame, bool dradisInit, MapId mapToLoad, IEnumerable<PlayerLoadInfo> playerInfo, string versionString, string mapMode, string platformId, IEnumerable<string> mutators, byte mutatorsNum, string orderRankedTeamName, string orderRankedTeamTag, string chaosRankedTeamName, string chaosRankedTeamTag, string metricsServerWebAddress, string metricsServerWebPath, ushort metricsServerPort, string dradisProdAddress, string dradisProdResource, ushort dradisProdPort, string dradisTestAddress, string dradisTestResource, ushort dradisTestPort, TipConfig tipConfig, ulong gameFeatures, IEnumerable<uint> disabledItems, IEnumerable<bool> enabledDradisMessages)
            : base(PacketCmd.S2CSynchVersion, 0)
        {
            VersionMatches = versionMatches;
            WriteToClientFile = writeToClientFile;
            MatchedGame = matchedGame;
            DradisInit = dradisInit;
            MapToLoad = mapToLoad;
            PlayerInfo = playerInfo?.ToList() ?? new List<PlayerLoadInfo>();
            VersionString = versionString ?? string.Empty;
            MapMode = mapMode ?? string.Empty;
            PlatformID = platformId ?? string.Empty;
            Mutators = mutators?.ToList() ?? new List<string>();
            MutatorsNum = mutatorsNum;
            OrderRankedTeamName = orderRankedTeamName ?? string.Empty;
            OrderRankedTeamTag = orderRankedTeamTag ?? string.Empty;
            ChaosRankedTeamName = chaosRankedTeamName ?? string.Empty;
            ChaosRankedTeamTag = chaosRankedTeamTag ?? string.Empty;
            MetricsServerWebAddress = metricsServerWebAddress ?? string.Empty;
            MetricsServerWebPath = metricsServerWebPath ?? string.Empty;
            MetricsServerPort = metricsServerPort;
            DradisProdAddress = dradisProdAddress ?? string.Empty;
            DradisProdResource = dradisProdResource ?? string.Empty;
            DradisProdPort = dradisProdPort;
            DradisTestAddress = dradisTestAddress ?? string.Empty;
            DradisTestResource = dradisTestResource ?? string.Empty;
            DradisTestPort = dradisTestPort;
            TipConfig = tipConfig ?? new TipConfig();
            GameFeatures = gameFeatures;
            DisabledItems = disabledItems?.ToList() ?? new List<uint>();
            EnabledDradisMessages = enabledDradisMessages?.ToList() ?? new List<bool>();

            WritePacket();
        }

        private void WritePacket()
        {
            if (PlayerInfo.Count > 12)
                throw new InvalidOperationException("Max 12 players");
            if (Mutators.Count > 8)
                throw new InvalidOperationException("Max 8 mutators");
            if (DisabledItems.Count > 64)
                throw new InvalidOperationException("Max 64 disabled items");
            if (EnabledDradisMessages.Count > 19)
                throw new InvalidOperationException("Max 19 dradis messages");

            byte bitfield = 0;
            if (VersionMatches)
                bitfield |= 1;
            if (WriteToClientFile)
                bitfield |= 2;
            if (MatchedGame)
                bitfield |= 4;
            if (DradisInit)
                bitfield |= 8;

            WriteByte(bitfield);

            WriteInt((int)MapToLoad);
            foreach (var player in PlayerInfo)
                WritePlayerInfo(player);
            for (var i = 0; i < 12 - PlayerInfo.Count; i++)
                WritePlayerInfo(new PlayerLoadInfo());

            WriteFixedString(VersionString, 256);
            WriteFixedString(MapMode, 128);
            WriteFixedString(PlatformID, 32);
            foreach (var mutator in Mutators)
                WriteFixedString(mutator, 64);
            for (var i = 0; i < 8 - Mutators.Count; i++)
                WriteFixedString("", 64);

            WriteByte(MutatorsNum);
            WriteFixedString(OrderRankedTeamName, 97);
            WriteFixedString(OrderRankedTeamTag, 25);
            WriteFixedString(ChaosRankedTeamName, 97);
            WriteFixedString(ChaosRankedTeamTag, 25);
            WriteFixedString(MetricsServerWebAddress, 256);
            WriteFixedString(MetricsServerWebPath, 256);
            WriteUShort(MetricsServerPort);
            WriteFixedString(DradisProdAddress, 256);
            WriteFixedString(DradisProdResource, 256);
            WriteUShort(DradisProdPort);
            WriteFixedString(DradisTestAddress, 256);
            WriteFixedString(DradisTestResource, 256);
            WriteUShort(DradisTestPort);
            WriteTipConfig(TipConfig);
            WriteULong(GameFeatures);

            foreach (var disabledItem in DisabledItems)
                WriteUInt(disabledItem);
            for (var i = 0; i < 64 - DisabledItems.Count; i++)
                WriteUInt(0);

            foreach (var enabledDradisMessage in EnabledDradisMessages)
                WriteBool(enabledDradisMessage);
            for (var i = 0; i < 19 - EnabledDradisMessages.Count; i++)
                WriteBool(false);
        }

        private void WritePlayerInfo(PlayerLoadInfo info)
        {
            WriteULong(info.SummonerId);
            WriteUShort(info.SummonorLevel);
            WriteUInt(info.SummonorSpell1);
            WriteUInt(info.SummonorSpell2);
            WriteByte(info.Bitfield);
            WriteUInt(info.TeamId);
            WriteFixedString(info.BotName, 64);
            WriteFixedString(info.BotSkinName, 64);
            WriteFixedString(info.EloRanking, 16);
            WriteInt(info.BotSkinID);
            WriteInt(info.BotDifficulty);
            WriteInt(info.ProfileIconId);
            WriteByte(info.AllyBadgeID);
            WriteByte(info.EnemyBadgeID);
        }

        private void WriteTipConfig(TipConfig tip)
        {
            WriteSByte(tip.TipID);
            WriteSByte(tip.ColorID);
            WriteSByte(tip.DurationID);
            WriteSByte(tip.Flags);
        }
    }

    internal class PlayerLoadInfo
    {
        public ulong SummonerId { get; }
        public ushort SummonorLevel { get; }
        public uint SummonorSpell1 { get; }
        public uint SummonorSpell2 { get; }
        //TODO: change bitfield to enum or variables
        public byte Bitfield { get; }
        public uint TeamId { get; }
        public string BotName { get; }
        public string BotSkinName { get; }
        public string EloRanking { get; }
        public int BotSkinID { get; }
        public int BotDifficulty { get; }
        public int ProfileIconId { get; }
        public byte AllyBadgeID { get; }
        public byte EnemyBadgeID { get; }

        public PlayerLoadInfo(ulong summonerId, ushort summonorLevel, uint summonorSpell1, uint summonorSpell2, byte bitfield, uint teamId, string botName, string botSkinName, string eloRanking, int botSkinId, int botDifficulty, int profileIconId, byte allyBadgeId, byte enemyBadgeId)
        {
            SummonerId = summonerId;
            SummonorLevel = summonorLevel;
            SummonorSpell1 = summonorSpell1;
            SummonorSpell2 = summonorSpell2;
            Bitfield = bitfield;
            TeamId = teamId;
            BotName = botName;
            BotSkinName = botSkinName;
            EloRanking = eloRanking;
            BotSkinID = botSkinId;
            BotDifficulty = botDifficulty;
            ProfileIconId = profileIconId;
            AllyBadgeID = allyBadgeId;
            EnemyBadgeID = enemyBadgeId;
        }

        public PlayerLoadInfo()
        {
            unchecked
            {
                SummonerId = (ulong)-1;
            }

            BotName = string.Empty;
            BotSkinName = string.Empty;
            EloRanking = string.Empty;
        }
    }

    public class TipConfig
    {
        public sbyte TipID { get; }
        public sbyte ColorID { get; }
        public sbyte DurationID { get; }
        public sbyte Flags { get; }

        public TipConfig(sbyte tipId, sbyte colorId, sbyte durationId, sbyte flags)
        {
            TipID = tipId;
            ColorID = colorId;
            DurationID = durationId;
            Flags = flags;
        }

        public TipConfig()
        {
        }
    }
}