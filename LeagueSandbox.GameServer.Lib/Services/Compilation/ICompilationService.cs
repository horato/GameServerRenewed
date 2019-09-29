using System.Collections.Generic;
using LeagueSandbox.GameServer.Lib.Services.Compilation.DTOs;

namespace LeagueSandbox.GameServer.Lib.Services.Compilation
{
    internal interface ICompilationService
    {
        AssemblyStream CompileInMemory(IEnumerable<SourceFile> files, string assemblyName, IEnumerable<string> externalReferences);
    }
}