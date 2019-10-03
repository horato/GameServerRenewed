using System;
using LeagueSandbox.GameServer.ENetCS;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal class PacketDefinitionReaderProcessor : IPacketDefinitionReaderProcessor
    {
        private readonly IPacketReader _packetReader;
        private readonly IUserProcessor _userProcessor;

        public PacketDefinitionReaderProcessor(IPacketReader packetReader, IUserProcessor userProcessor)
        {
            _packetReader = packetReader;
            _userProcessor = userProcessor;
        }

        public void ProcessRequest(Peer peer, byte[] data, Channel channel)
        {
            var request = _packetReader.ReadPacket(data, channel);
            if (request == null)
                throw new InvalidOperationException("Failed to read request.");
            
            _userProcessor.ProcessRequest(peer, request);
        }
    }
}