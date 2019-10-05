using System.IO;
using LeagueSandbox.GameServer.Core.Compilation.DTOs;

namespace LeagueSandbox.GameServer.Utils.Scripting
{
    internal static class TemporaryAssemblyLoader
    {
        public static TemporaryAssembly LoadAssembly(AssemblyStream stream)
        {
            var context = new SimpleAssemblyLoadContext();

            using (var assemblyStream = new MemoryStream(stream.AssemblyBytes))
            using (var pdbStream = new MemoryStream(stream.DebuggingInformationBytes))
            {
                var assembly = context.LoadFromStream(assemblyStream, pdbStream);
                return new TemporaryAssembly(assembly, context);
            }
        }
    }
}
