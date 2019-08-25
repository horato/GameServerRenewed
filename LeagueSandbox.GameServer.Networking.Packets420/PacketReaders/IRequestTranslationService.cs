using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
	internal interface IRequestTranslationService
	{
		IRequestDefinition TranslateRequest(IRequestPacketDefinition request);
	}
}
