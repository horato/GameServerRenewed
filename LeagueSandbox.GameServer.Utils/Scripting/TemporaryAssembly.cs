using System.Reflection;

namespace LeagueSandbox.GameServer.Utils.Scripting
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
