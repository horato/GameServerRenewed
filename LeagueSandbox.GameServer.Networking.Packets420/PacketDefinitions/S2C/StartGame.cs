using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class StartGame : BasePacket
    {
        public StartGame(bool enablePause) : base(PacketCmd.S2CStartGame)
        {
            byte bitfield = 0;
            if (enablePause)
                bitfield |= 1;

            WriteByte(bitfield);
        }
    }
}
