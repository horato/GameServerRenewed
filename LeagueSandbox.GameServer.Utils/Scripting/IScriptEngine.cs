using System;
using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Utils.Scripting
{
    public interface IScriptEngine
    {
        void LoadScripts(string path, string assemblyName);
        IEnumerable<Type> GetAllScripts();
    }
}