using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
    internal interface IRequestDTOTranslationService
    {
        MovementData TranslateMovementData(MovementDataNormal movementData);
    }
}