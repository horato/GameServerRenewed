using System;
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
        public DateTime BuildDate => System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
        public TimeSpan RefreshRate { get; }

        public ServerInformationData(DateTime startTime, string version, TimeSpan refreshRate)
        {
            StartTime = startTime;
            Version = version;
            RefreshRate = refreshRate;
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
