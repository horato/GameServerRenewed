using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Core
{
	public interface IPacketReader
	{
		IRequestDefinition ReadPacket(byte[] data, Channel channel);
	}
}
