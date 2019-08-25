using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketWriters
{
    public class PacketWriter : IPacketWriter
    {
        public byte[] WriteKeyCheckResponse(ulong summonerId, int clientId)
        {
            return new KeyCheckResponse(summonerId, clientId).GetBytes();
        }

        public byte[] WriteNotifyQueryStatus()
        {
            return new QueryStatus().GetBytes();
        }
    }
}
