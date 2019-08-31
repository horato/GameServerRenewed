using System;
using System.Collections.Generic;
using System.IO;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class OnEnterLocalVisibilityClient : BasePacket
    {
        public IList<BasePacket> Packets { get; set; }

        public float MaxHealth { get; set; }
        public float Health { get; set; }
        
        public OnEnterLocalVisibilityClient(uint senderNetId, IList<BasePacket> packets, float maxHealth, float health) : base(PacketCmd.S2COnEnterLocalVisibilityClient, senderNetId)
        {
            Packets = packets;
            MaxHealth = maxHealth;
            Health = health;

            WritePacket();
        }

        private void WritePacket()
        {
            using (var stream = new MemoryStream())
            using (var writer2 = new BinaryWriter(stream))
            {
                foreach (var packet in Packets)
                {
                    var data = packet.GetBytes();
                    if (data.Length > 0x1FFF)
                    {
                        throw new InvalidOperationException("Packet is too large");
                    }
                    writer2.Write((ushort)data.Length);
                    writer2.Write(data);
                }

                var buffer = stream.ToArray();
                if (buffer.Length > 0x1FFF)
                    throw new InvalidOperationException("Packet data are too large");

                WriteUShort((ushort)(buffer.Length & 0x1FFF));
                WriteBytes(buffer);
            }

            WriteFloat(MaxHealth);
            WriteFloat(Health);
        }
    }
}