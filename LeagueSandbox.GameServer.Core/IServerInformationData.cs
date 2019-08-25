using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LeagueSandbox.GameServer.Core
{
    public interface IServerInformationData
    {
        IEnumerable<Assembly> GetAllApplicationAssemblies();
    }
}
