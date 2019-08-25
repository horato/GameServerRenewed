using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal class ServerActionProcessor : IServerActionProcessor
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IDictionary<Type, Type> _serverActions;

        public ServerActionProcessor(IServerActionProvider serverActionProvider, IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            _serverActions = serverActionProvider.ProvideServerActions();
        }

        public void ProcessRequest(ulong senderSummonerId, IRequestDefinition request)
        {
            if (!_serverActions.ContainsKey(request.GetType()))
                throw new InvalidOperationException($"No server action found for request {request}");

            var serverActionType = _serverActions[request.GetType()];
            var serverActionInstance = _unityContainer.Resolve(serverActionType) as IServerAction;
            if (serverActionInstance == null)
                throw new InvalidOperationException($"Failed to cast {serverActionType} to {nameof(IServerAction)}");

            serverActionInstance.ProcessRequest(senderSummonerId, request);
        }
    }
}
