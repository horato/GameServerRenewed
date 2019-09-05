using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class OnReplication : BasePacket
    {
        public uint SyncId { get; }
        public IList<ReplicationData> ReplicationData { get; }

        public OnReplication(uint syncId, IList<ReplicationData> replicationData) : base(PacketCmd.OnReplication)
        {
            SyncId = syncId;
            ReplicationData = replicationData;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteUInt(SyncId);
            var count = ReplicationData.Count;
            if (count > 0xFF)
                throw new InvalidOperationException("Too many replication data in list > 0xFF");

            WriteByte((byte)count);
            foreach (var data in ReplicationData)
                WriteReplicationData(data);
        }

        private void WriteReplicationData(ReplicationData data)
        {
            byte primaryIdArray = 0;
            foreach (var kvp in data.Data)
            {
                primaryIdArray |= (byte)kvp.Key;
            }

            WriteByte(primaryIdArray);
            WriteUInt(data.UnitNetID);

            foreach (var masterMaskValuesPair in data.Data.OrderBy(x => (byte)x.Key))
            {
                uint secondaryIdArray = 0;
                foreach (var fieldMask in masterMaskValuesPair.Value.Keys)
                {
                    primaryIdArray |= (byte)fieldMask;
                }

                WriteUInt(secondaryIdArray);

                var values = masterMaskValuesPair.Value.OrderBy(x => (uint)x.Key).SelectMany(x => ConvertValueToByteArray(x.Value)).ToArray();
                WriteByte((byte)values.Length);
                WriteBytes(values);
            }
        }

        private byte[] ConvertValueToByteArray(object value)
        {
            switch (value)
            {
                case bool b:
                    return PackUInt32(b ? 1u : 0u);
                case sbyte sb:
                    return PackInt32(sb);
                case byte b:
                    return PackUInt32(b);
                case short s:
                    return PackInt32(s);
                case ushort us:
                    return PackUInt32(us);
                case int i:
                    return PackInt32(i);
                case uint ui:
                    return PackUInt32(ui);
                case float f:
                    return PackFloat(f);
                case double _:
                case long _:
                case ulong _:
                    throw new InvalidOperationException("Long/ULong/Double values are not supported.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "This stat value is not supported");
            }
        }

        private byte[] PackUInt32(uint data)
        {
            var result = new List<byte>();
            var num = data;
            while (num >= 0x80)
            {
                result.Add((byte)(num | 0x80));
                num >>= 7;
            }

            result.Add((byte)num);
            return result.ToArray();
        }

        private byte[] PackInt32(int data)
        {
            return PackUInt32((uint)data);
        }

        private byte[] PackFloat(float data)
        {
            var bytes = BitConverter.GetBytes(data);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0 && bytes[3] == 0)
            {
                return new byte[] { 0xFF };
            }

            if (bytes[0] >= 0xFE)
            {
                return new byte[] { 0xFE }.Concat(bytes).ToArray();
            }

            return bytes;
        }
    }
}
