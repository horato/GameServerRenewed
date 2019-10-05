using System.Reflection;
using System.Runtime.Loader;

namespace LeagueSandbox.GameServer.Utils.Scripting
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
