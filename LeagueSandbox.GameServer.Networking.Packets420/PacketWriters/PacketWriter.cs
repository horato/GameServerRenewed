using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketWriters
{
    public class PacketWriter : IPacketWriter
    {
        private readonly IEnumTranslationService _enumTranslationService;

        public PacketWriter(IUnityContainer unityContainer)
        {
            _enumTranslationService = unityContainer.Resolve<IEnumTranslationService>();
        }

        public byte[] WriteKeyCheckResponse(ulong summonerId, int clientId)
        {
            return new KeyCheckResponse(summonerId, clientId).GetBytes();
        }

        public byte[] WriteNotifyQueryStatus()
        {
            return new QueryStatus().GetBytes();
        }

        public byte[] WriteSynchVersion(bool versionMatches, MapType mapId, IEnumerable<IObjAiHero> players, string version)
        {
            return new SynchVersionResponse
            (
                versionMatches,
                false,
                false,
                false,
                _enumTranslationService.TranslateMapType(mapId),
                TranslatePlayers(players),
                version,
                "CLASSIC",
                "NA",
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
                487826,
                new List<uint>(),
                new List<bool>()
            ).GetBytes();
        }

        private IEnumerable<PlayerLoadInfo> TranslatePlayers(IEnumerable<IObjAiHero> players)
        {
            if (players == null)
                yield break;

            foreach (var player in players)
            {
                yield return new PlayerLoadInfo();
            }
        }
    }
}
