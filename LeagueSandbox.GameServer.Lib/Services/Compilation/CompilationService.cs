using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LeagueSandbox.GameServer.Lib.Services.Compilation.DTOs;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace LeagueSandbox.GameServer.Lib.Services.Compilation
{
    internal class CompilationService : ICompilationService
    {
        private readonly CSharpParseOptions _parseOptions = new CSharpParseOptions(LanguageVersion.Latest, DocumentationMode.None, SourceCodeKind.Regular, new List<string>());

        public AssemblyStream CompileInMemory(IEnumerable<SourceFile> files, string assemblyName, IEnumerable<string> externalReferences)
        {
            var compilation = CreateCompilation(files, assemblyName, externalReferences);

            using (var assemblyStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
                var result = compilation.Emit(assemblyStream, pdbStream);
                if (!result.Success)
                    throw new InvalidOperationException("Compilation failed");

                assemblyStream.Seek(0, SeekOrigin.Begin);
                pdbStream.Seek(0, SeekOrigin.Begin);
                return new AssemblyStream(assemblyStream.ToArray(), pdbStream.ToArray(), assemblyName);
            }
        }

        private CSharpCompilation CreateCompilation(IEnumerable<SourceFile> files, string assemblyName, IEnumerable<string> externalReferences)
        {
            var trees = ParseSyntaxTrees(files);
            var compilationOptions = CreateCompilationOptions();
            var references = GetMetadataReferences(externalReferences);

            return CSharpCompilation.Create(assemblyName, trees, references, compilationOptions);
        }


        private IEnumerable<SyntaxTree> ParseSyntaxTrees(IEnumerable<SourceFile> files)
        {
            var result = new ConcurrentBag<SyntaxTree>();

            // This can be cached for faster script reloading
            Parallel.ForEach(files, x =>
            {
                var tree = CSharpSyntaxTree.ParseText(x.Content, _parseOptions, x.FileFullPath, Encoding.Unicode);

                result.Add(tree);
            });

            return result;
        }

        private CSharpCompilationOptions CreateCompilationOptions()
        {
            return new CSharpCompilationOptions
            (
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: GetOptimizationLevel(),
                platform: Platform.AnyCpu
            );
        }

        private OptimizationLevel GetOptimizationLevel()
        {
#if DEBUG
            return OptimizationLevel.Debug;
#else
            return OptimizationLevel.Release;
#endif
        }

        private static IEnumerable<MetadataReference> GetMetadataReferences(IEnumerable<string> externalReferences)
        {
            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location), //mscorlib.dll
                MetadataReference.CreateFromFile(typeof(Cookie).Assembly.Location), //System.dll
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location), //System.Core.dll
                MetadataReference.CreateFromFile(typeof(DataTable).Assembly.Location), //System.Data.dll
                MetadataReference.CreateFromFile(typeof(XmlDocument).Assembly.Location), //System.Xml.dll
            };

            if (externalReferences != null)
            {
                foreach (var externalReference in externalReferences)
                {
                    references.Add(MetadataReference.CreateFromFile(externalReference));
                }
            }

            return references;
        }
    }
}
