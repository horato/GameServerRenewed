namespace LeagueSandbox.GameServer.Networking.Communication
{
	internal interface IServerHost
	{
		void InitServer(string host, ushort port);
		void NetLoop();
	}
}