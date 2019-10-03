using LeagueSandbox.GameServer.ENetCS;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal interface IPacketDefinitionReaderProcessor
    {
        void ProcessRequest(Peer peer, byte[] data, Channel channel);
    }
}
