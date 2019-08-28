﻿using System;
using System.Collections.Generic;
using System.Reflection;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Networking.Packets420;

namespace LeagueSandbox.GameServer.Lib
{
    public class ServerInformationData : IServerInformationData
    {
        public DateTime StartTime { get; }
        public string Version { get; }

        public ServerInformationData(DateTime startTime, string version)
        {
            StartTime = startTime;
            Version = version;
        }

        public IEnumerable<Assembly> GetAllApplicationAssemblies()
        {
            yield return CoreAssemblyDefiningType.Assembly;
            yield return LibAssemblyDefiningType.Assembly;
            yield return NetworkingAssemblyDefiningType.Assembly;
            yield return PacketsAssemblyDefiningType.Assembly;
        }
    }
}