using System;
using System.Runtime.CompilerServices;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;

[assembly: InternalsVisibleTo("LeagueSandbox.GameServer.Networking.Packets420.Tests")]
namespace LeagueSandbox.GameServer.Networking.Packets420.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class PacketAttribute : Attribute
	{
		public PacketCmd PacketId { get; }
		public Channel ChannelId { get; }

		public PacketAttribute(PacketCmd packetId, Channel channel)
		{
			PacketId = packetId;
			ChannelId = channel;
		}

		public PacketAttribute(PacketCmd packetId) : this(packetId, Channel.ClientToServer)
		{

		}
	}
}
