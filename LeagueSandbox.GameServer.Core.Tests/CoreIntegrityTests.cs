using System;
using System.Linq;
using System.Reflection;
using System.Text;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Injection;

namespace LeagueSandbox.GameServer.Lib.Tests
{
    [TestClass]
    public class IntegrityTests : WhereContainerIsAvailable
    {
        [TestMethod]
        public void AllInjectionMethodsHaveCorrectSettings()
        {
            var sb = new StringBuilder();
            var types = GetAllApplicationAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(INeedDependencies).IsAssignableFrom(x)).Where(x => !x.IsAbstract && !x.IsInterface).ToList();
            foreach (var type in types)
            {
                var methods = type.GetMethods().Where(x => x.GetCustomAttribute<InjectionMethodAttribute>() != null).ToList();
                if (methods.Count > 1)
                    sb.Append($"More than one injection method found on type {type}");
                if (methods.Count != 1)
                    continue;

                var method = methods.Single();
                if (!method.IsPublic)
                    sb.Append($"Method {method.Name} on type {type.FullName} must be public");
                if (method.IsStatic)
                    sb.Append($"Method {method.Name} on type {type.FullName} must not be static");
                if (method.IsAbstract)
                    sb.Append($"Method {method.Name} on type {type.FullName} must not be abstract");
                if (method.ReturnType != typeof(void))
                    sb.Append($"Method {method.Name} on type {type.FullName} must return void");
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                Assert.Fail(sb.ToString());
        }

        [TestMethod]
        public void AllClassedWithInjectionMethodsMustDeriveFromINeedDependencies()
        {
            var sb = new StringBuilder();
            var types = GetAllApplicationAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.GetMethods().Any(y => y.GetCustomAttribute<InjectionMethodAttribute>() != null)).Where(x => !x.IsAbstract && !x.IsInterface).ToList();
            foreach (var type in types)
            {
                if (!typeof(INeedDependencies).IsAssignableFrom(type))
                    sb.Append($"{type.FullName} has injection method but does not derive from {nameof(INeedDependencies)}");
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                Assert.Fail(sb.ToString());
        }

        [TestMethod]
        public void DependencyAttributeIsNotUsed()
        {
            var sb = new StringBuilder();
            var types = GetAllApplicationAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.GetProperties().Any(y => y.GetCustomAttribute<DependencyAttribute>() != null)).Where(x => !x.IsAbstract && !x.IsInterface).ToList();
            foreach (var type in types)
            {
                sb.Append($"Type {type.FullName} contains property with Dependency attribute.");
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                Assert.Fail(sb.ToString());
        }

        [TestMethod]
        public void AllRequestDefinitionsMustBeInsideCoreProject()
        {
            var assemblies = GetAllApplicationAssemblies();
            var requestDefinitions = assemblies.SelectMany(x => x.GetTypes()).Where(x => typeof(IRequestDefinition).IsAssignableFrom(x));
            var requestDefinitionsOutsideCore = requestDefinitions.Where(x => x.Assembly != CoreAssemblyDefiningType.Assembly).ToList();
            if (requestDefinitionsOutsideCore.Any())
                Assert.Fail($"All request definitions must be inside Core project.{Environment.NewLine}{string.Join(Environment.NewLine, requestDefinitionsOutsideCore)}");
        }

        [TestMethod]
        public void AllRequestDefinitionsMustHaveSingleServerAction()
        {
            var errors = new StringBuilder();
            var assemblies = GetAllApplicationAssemblies();
            var allTypes = assemblies.SelectMany(x => x.GetTypes()).Where(x => !x.IsAbstract).ToList();
            var requests = allTypes.Where(x => typeof(IRequestDefinition).IsAssignableFrom(x));
            var serverActions = allTypes.Where(x => typeof(IServerAction).IsAssignableFrom(x)).ToList();
            foreach (var request in requests)
            {
                var requestServerActions = serverActions.Where(x => x.GenericBaseClassHasArgumentOfTypeInHierarchy(typeof(ServerActionBase<>), request)).ToList();
                if (requestServerActions.Count > 1)
                    errors.AppendLine($"More than one ServerAction found for request {request}: {Environment.NewLine}{string.Join(Environment.NewLine, requestServerActions)}");
                if (requestServerActions.Count == 0)
                    errors.AppendLine($"No ServerAction found for request {request}");
            }

            if (!string.IsNullOrWhiteSpace(errors.ToString()))
                Assert.Fail(errors.ToString());
        }
    }
}
