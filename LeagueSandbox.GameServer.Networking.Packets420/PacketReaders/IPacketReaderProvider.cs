using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
	internal interface IPacketReaderProvider
	{
		IDictionary<Channel, IDictionary<PacketCmd, Type>> ProvidePackets();
	}
}