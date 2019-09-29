using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace LeagueSandbox.GameServer.Lib.Services.Compilation.DTOs
{
    internal class SimpleAssemblyLoadContext : AssemblyLoadContext
    {
        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }

        internal void Unload()
        {
            //TODO: Remove this once unloading is implemented in .netstandard
        }
    }
}
