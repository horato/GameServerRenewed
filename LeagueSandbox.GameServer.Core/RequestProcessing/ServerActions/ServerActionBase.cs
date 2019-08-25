using System;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions
{
    public abstract class ServerActionBase<TRequest> : IServerAction
        where TRequest : RequestDefinition
    {
        public void ProcessRequest(ulong senderSummonerId, TRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ProcessRequestInternal(senderSummonerId, request);
        }

        public void ProcessRequest(ulong senderSummonerId, IRequestDefinition request)
        {
            var genericRequest = request as TRequest;
            if (genericRequest == null)
                throw new InvalidOperationException($"Failed to cast {request} to {typeof(TRequest)}");

            ProcessRequest(senderSummonerId, genericRequest);
        }

        protected abstract void ProcessRequestInternal(ulong senderSummonerId, TRequest request);
    }
}
