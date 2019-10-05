using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Compilation.DTOs;

namespace LeagueSandbox.GameServer.Core.Compilation
{
    public interface ICompilationService
    {
        AssemblyStream CompileInMemory(IEnumerable<SourceFile> files, string assemblyName, IEnumerable<string> externalReferences);
    }
}