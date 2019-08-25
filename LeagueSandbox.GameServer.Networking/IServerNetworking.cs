namespace LeagueSandbox.GameServer.Networking
{
	public interface IServerNetworking
	{
		void Initialize(string host, ushort port, string blowfishKey);
		void StartNetworkLoop();
		void StopNetworkLoop();
	}
}