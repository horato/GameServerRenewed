using ENet;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication
{
	internal interface IPacketHandler
	{
		void HandlePacket(Peer peer, Packet packet, Channel channel);
		void HandleDisconnect(Peer peer);
	}
}