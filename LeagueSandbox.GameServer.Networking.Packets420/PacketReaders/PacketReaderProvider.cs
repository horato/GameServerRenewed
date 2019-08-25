using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
	internal class PacketReaderProvider : IPacketReaderProvider
	{
		public IDictionary<Channel, IDictionary<PacketCmd, Type>> ProvidePackets()
		{
			var result = new Dictionary<Channel, IDictionary<PacketCmd, Type>>();
			var assemblies = new[] { PacketsAssemblyDefiningType.Assembly };
			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(PacketAttribute)));
				foreach (var type in types)
				{
					var attribute = type.GetCustomAttribute<PacketAttribute>();
					if (!result.ContainsKey(attribute.ChannelId))
						result.Add(attribute.ChannelId, new Dictionary<PacketCmd, Type>());

					var channelPackets = result[attribute.ChannelId];
					if(channelPackets.ContainsKey(attribute.PacketId))
						throw new InvalidOperationException($"Packet definition already exists for channel/cmd combination {attribute.ChannelId}/{attribute.PacketId}");

					channelPackets.Add(attribute.PacketId, type);
				}
			}

			return result;
		}
	}
}
