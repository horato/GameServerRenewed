using System;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.ENetCS;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal class PacketProcessor : IPacketProcessor
    {
        private readonly IPacketDefinitionReaderProcessor _definitionReaderProcessor;

        public PacketProcessor(IPacketDefinitionReaderProcessor definitionReaderProcessor)
        {
            _definitionReaderProcessor = definitionReaderProcessor;
        }

        public void ProcessRequest(Peer peer, Packet packet, Channel channel)
        {
            try
            {
                var data = packet.GetBytes();
                _definitionReaderProcessor.ProcessRequest(peer, data, channel);
            }
            catch (Exception e)
            {
                LoggerProvider.GetLogger().Error("Error occured while processing packet.", e);
            }
        }
    }
}
