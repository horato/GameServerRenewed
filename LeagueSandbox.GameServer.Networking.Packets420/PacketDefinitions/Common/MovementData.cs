using System;
using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal abstract class MovementData
    {
        public abstract MovementDataType Type { get; }
        public uint SyncID { get; }

        protected MovementData(uint syncId)
        {
            SyncID = syncId;
        }

        public abstract byte[] GetData();
    }
}
