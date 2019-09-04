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
            foreach (var kvp in data.Data.OrderBy(x => (byte)x.Key))
            {
                primaryIdArray |= (byte)kvp.Key;
            }

            WriteByte(primaryIdArray);
            WriteUInt(data.UnitNetID);

            foreach (var masterMaskValuesPair in data.Data.OrderBy(x => (byte)x.Key))
            {
                var masterMask = masterMaskValuesPair.Key;
                foreach (var fieldMaskValuePair in masterMaskValuesPair.Value)
                {
                    var fieldMask = fieldMaskValuePair.Key;
                    var statValue = fieldMaskValuePair.Value;
                    var valueBytes = ConvertValueToByteArray(statValue);

                    WriteUInt((uint)fieldMask);
                    WriteByte((byte)valueBytes.Length);
                    WriteBytes(valueBytes);
                }
            }
        }

        private byte[] ConvertValueToByteArray(object value)
        {
            switch (value)
            {
                case bool b:
                    return BitConverter.GetBytes(b);
                case sbyte sb:
                    return BitConverter.GetBytes(sb);
                case byte b:
                    return BitConverter.GetBytes(b);
                case short s:
                    return BitConverter.GetBytes(s);
                case ushort us:
                    return BitConverter.GetBytes(us);
                case int i:
                    return BitConverter.GetBytes(i);
                case uint ui:
                    return BitConverter.GetBytes(ui);
                case long l:
                    return BitConverter.GetBytes(l);
                case ulong ul:
                    return BitConverter.GetBytes(ul);
                case float f:
                    return BitConverter.GetBytes(f);
                case double d:
                    return BitConverter.GetBytes(d);
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "This stat value is not supported");
            }
        }
    }
}