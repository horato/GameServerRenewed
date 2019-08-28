using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
    internal class PacketReader : IPacketReader
    {
        private readonly IBlowfishCrypter _blowfishCrypter;
        private readonly IRequestTranslationService _requestTranslationService;
        private readonly IDictionary<Channel, IDictionary<PacketCmd, Type>> _packetDefinitionDictionary;

        public PacketReader(IUnityContainer container, IBlowfishCrypter blowfishCrypter)
        {
            _blowfishCrypter = blowfishCrypter;
            _requestTranslationService = container.Resolve<IRequestTranslationService>();
            _packetDefinitionDictionary = container.Resolve<IPacketReaderProvider>().ProvidePackets();
        }

        public IRequestDefinition ReadPacket(byte[] data, Channel channel)
        {
            if (data.Length < 1)
                throw new InvalidOperationException($"Received invalid data on channel {channel}");
            if (!_packetDefinitionDictionary.ContainsKey(channel))
                throw new InvalidOperationException($"Packet definitions for channel {channel} not found.");

            var decryptedData = data;
            if (channel != Channel.Default && data.Length >= 8)
                decryptedData = _blowfishCrypter.Decipher(data);

            var packetType = (PacketCmd)decryptedData[0];

            LoggerProvider.GetLogger().Debug($"Received {packetType}");

            var channelPacketDefinitions = _packetDefinitionDictionary[channel];
            if (!channelPacketDefinitions.ContainsKey(packetType))
                throw new InvalidOperationException($"Definition for packet {packetType} not found in channel {channel}");

            var packetDefinitionType = _packetDefinitionDictionary[channel][packetType];
            var packetDefinitionInstance = Activator.CreateInstance(packetDefinitionType, decryptedData) as IRequestPacketDefinition;
            return _requestTranslationService.TranslateRequest(packetDefinitionInstance);
        }
    }
}
