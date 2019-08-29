using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal interface IDTOTranslationService
    {
        PlayerLoadInfo TranslatePlayerLoadInfo(IPlayer player);
    }
}