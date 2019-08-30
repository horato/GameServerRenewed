using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class EndSpawn : BasePacket
    {
        public EndSpawn() : base(PacketCmd.S2CEndSpawn)
        {

        }
    }
}
