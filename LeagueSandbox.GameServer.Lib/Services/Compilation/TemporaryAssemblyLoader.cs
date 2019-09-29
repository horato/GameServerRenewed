using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using LeagueSandbox.GameServer.Lib.Services.Compilation.DTOs;

namespace LeagueSandbox.GameServer.Lib.Services.Compilation
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
