using System;
using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Lib.Scripting
{
    internal interface IScriptEngine
    {
        void LoadScripts(string path);
        IEnumerable<Type> GetAllScripts();
    }
}