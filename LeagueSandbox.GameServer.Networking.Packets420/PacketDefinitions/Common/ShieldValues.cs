using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class ShieldValues
    {
        public float Magical { get; }
        public float Phyisical { get; }
        public float MagicalAndPhysical { get; }

        public ShieldValues(float magical, float phyisical, float magicalAndPhysical)
        {
            Magical = magical;
            Phyisical = phyisical;
            MagicalAndPhysical = magicalAndPhysical;
        }
    }
}
