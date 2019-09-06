﻿using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class ReplicationData
    {
        public uint UnitNetID { get; }
        public IDictionary<MasterMask, IDictionary<Enum, object>> Data { get; }

        public ReplicationData(uint unitNetId, IDictionary<MasterMask, IDictionary<Enum, object>> data)
        {
            UnitNetID = unitNetId;
            Data = data;
        }
    }
}
