using System;
using System.Collections.Generic;
using System.Reflection;

namespace LeagueSandbox.GameServer.Core
{
    public interface IServerInformationData
    {
        IEnumerable<Assembly> GetAllApplicationAssemblies();
        DateTime StartTime { get; }
        string Version { get; }
    }
}
