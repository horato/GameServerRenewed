using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LeagueSandbox.GameServer.Lib.Services.Compilation.DTOs
{
    internal class TemporaryAssembly
    {
        public Assembly Assembly { get; }
        public SimpleAssemblyLoadContext Context { get; }

        public TemporaryAssembly(Assembly assembly, SimpleAssemblyLoadContext context)
        {
            Assembly = assembly;
            Context = context;
        }
    }
}
