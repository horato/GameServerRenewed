using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SCharSelected)]
    internal class CharSelectedRequest : IRequestPacketDefinition
    {
        public CharSelectedRequest(byte[] data)
        {
           
        }
    }
}
