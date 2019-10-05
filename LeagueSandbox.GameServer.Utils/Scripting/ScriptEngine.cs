using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.Compilation;
using LeagueSandbox.GameServer.Core.Compilation.DTOs;

namespace LeagueSandbox.GameServer.Utils.Scripting
{
    internal class ScriptEngine : IScriptEngine
    {
        private readonly ICompilationService _compilationService;
        private string _assemblyName;
        private TemporaryAssembly _assembly;

        public ScriptEngine(ICompilationService compilationService)
        {
            _compilationService = compilationService;
        }

        public void LoadScripts(string path, string assemblyName)
        {
            _assembly?.Context.Unload();

            var files = GetFilesFromPath(path);
            _assemblyName = assemblyName;

            var externalReferences = new[]
            {
                CoreAssemblyDefiningType.Assembly.Location,
                UtilsAssemblyDefiningType.Assembly.Location
            };

            var stream = _compilationService.CompileInMemory(files, _assemblyName, externalReferences);
            _assembly = TemporaryAssemblyLoader.LoadAssembly(stream);
        }

        private IEnumerable<SourceFile> GetFilesFromPath(string path)
        {
            var scriptFiles = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories).Where(x =>
            {
                var directories = x.Remove(0, path.Length).Split(Path.DirectorySeparatorChar).ToList();
                return !directories.Contains("bin") && !directories.Contains("obj");
            });

            var result = new ConcurrentBag<SourceFile>();
            Parallel.ForEach(scriptFiles, x =>
            {
                var content = File.ReadAllText(x);
                result.Add(new SourceFile(Path.GetFullPath(x), Path.GetFileName(x), content));
            });

            return result;
        }

        public IEnumerable<Type> GetAllScripts()
        {
            return _assembly.Assembly.GetExportedTypes();
        }
    }
}
