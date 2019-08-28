namespace LeagueSandbox.GameServer.Networking
{
	public interface INetworkController
	{
		void Initialize(string host, ushort port, string blowfishKey);
		void StartNetworkLoop();
		void StopNetworkLoop();
	}
}