using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Networking.Communication
{
	internal class ServerActionProvider : IServerActionProvider
    {
        private readonly IServerInformationData _serverData;

        public ServerActionProvider(IServerInformationData serverData)
        {
            _serverData = serverData;
        }

        public IDictionary<Type, Type> ProvideServerActions()
        {
            var result = new Dictionary<Type, Type>();
            var assemblies = _serverData.GetAllApplicationAssemblies();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsAbstract)
                        continue;
                    if (!type.IsInheritedFromGenericBase(typeof(ServerActionBase<>)))
                        continue;

                    var requestType = type.GetArgumentFromGenericBaseTypeInHierarchy(typeof(ServerActionBase<>), 0);
                    if (result.ContainsKey(requestType))
                        throw new InvalidOperationException($"Result already contains request server action for request {requestType}");

                    result.Add(requestType, type);
                }
            }

            return result;
        }
    }
}
