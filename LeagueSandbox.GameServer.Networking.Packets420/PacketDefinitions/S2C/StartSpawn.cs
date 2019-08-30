using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class StartSpawn : BasePacket
    {
        public StartSpawn(byte blueBotsCount, byte redBotsCount) : base(PacketCmd.S2CStartSpawn)
        {
            WriteByte(blueBotsCount);
            WriteByte(redBotsCount);
        }
    }
}
