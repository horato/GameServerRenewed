namespace LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions
{
	public interface IServerAction
	{
		void ProcessRequest(ulong senderSummonerId, IRequestDefinition request);
	}
}