namespace LeagueSandbox.GameServer.Networking.Core
{
    public interface IPacketWriter
    {
        byte[] WriteKeyCheckResponse(ulong summonerId, int clientId);
        byte[] WriteNotifyQueryStatus();
    }
}
