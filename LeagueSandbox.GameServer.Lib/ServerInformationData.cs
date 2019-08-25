using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Networking.Packets420;

namespace LeagueSandbox.GameServer.Lib
{
    public class ServerInformationData : IServerInformationData
    {
        public IEnumerable<Assembly> GetAllApplicationAssemblies()
        {
            yield return CoreAssemblyDefiningType.Assembly;
            yield return LibAssemblyDefiningType.Assembly;
            yield return NetworkingAssemblyDefiningType.Assembly;
            yield return PacketsAssemblyDefiningType.Assembly;
        }
    }
}
