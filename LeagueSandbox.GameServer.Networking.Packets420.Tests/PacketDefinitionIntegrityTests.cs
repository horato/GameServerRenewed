using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueSandbox.GameServer.Networking.Packets420.Tests
{
    [TestClass]
    public class PacketDefinitionIntegrityTests
    {
        [TestMethod]
        public void AllPacketDefinitionsMustHaveCorrectConstructor()
        {
            var failedDefinitions = new List<Type>();
            var assemblies = new[] { PacketsAssemblyDefiningType.Assembly };
            foreach (var assembly in assemblies)
            {
                var packetDefinitions = assembly.GetTypes().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(PacketAttribute)));
                foreach (var packetDefinition in packetDefinitions)
                {
                    var constructorFound = false;
                    foreach (var constructor in packetDefinition.GetConstructors())
                    {
                        var parameters = constructor.GetParameters();
                        if (parameters.Length == 1 && parameters.Any(x => x.ParameterType == typeof(byte[])))
                            constructorFound = true;
                    }

                    if (!constructorFound)
                        failedDefinitions.Add(packetDefinition);
                }
            }

            if (failedDefinitions.Any())
                Assert.Fail($"All packet definitions must contain a constructor with single byte[] parameter.{Environment.NewLine}{string.Join(Environment.NewLine, failedDefinitions)}");
        }

        [TestMethod]
        public void AllPacketDefinitionsMustHavePacketAttribute()
        {
            var types = GetAllTypes().Where(x => typeof(IRequestPacketDefinition).IsAssignableFrom(x)).Where(x => !x.IsAbstract && !x.IsInterface);
            var typesWithoutAttribute = types.Where(x => x.GetCustomAttribute<PacketAttribute>() == null).ToList();
            if (typesWithoutAttribute.Any())
                Assert.Fail($"All packet definitions must contain {nameof(PacketAttribute)}{Environment.NewLine}{string.Join(Environment.NewLine, typesWithoutAttribute)}");
        }

        [TestMethod]
        public void AllPacketDefinitionsMustDeriveFromRequestPacketDefinition()
        {
            var types = GetAllTypes().Where(x => x.GetCustomAttribute<PacketAttribute>() != null).Where(x => !x.IsAbstract && !x.IsInterface);
            var typesWithoutAttribute = types.Where(x => !typeof(IRequestPacketDefinition).IsAssignableFrom(x)).ToList();
            if (typesWithoutAttribute.Any())
                Assert.Fail($"All packet definitions must derive from {nameof(IRequestPacketDefinition)}{Environment.NewLine}{string.Join(Environment.NewLine, typesWithoutAttribute)}");
        }

        private IEnumerable<Type> GetAllTypes()
        {
            var assemblies = new[] { PacketsAssemblyDefiningType.Assembly };
            return assemblies.SelectMany(x => x.GetTypes());
        }
    }
}
