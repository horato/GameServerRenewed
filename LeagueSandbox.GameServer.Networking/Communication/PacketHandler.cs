﻿using System;
using System.Collections.Generic;
using ENet;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Communication.Processors;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Communication
{
    internal class PacketHandler : IPacketHandler
    {
        private readonly IPacketProcessor _packetProcessor;

        public PacketHandler(IPacketProcessor packetProcessor)
        {
            _packetProcessor = packetProcessor;
        }

        public void HandlePacket(Peer peer, Packet packet, Channel channel)
        {
            _packetProcessor.ProcessRequest(peer, packet, channel);
        }

        public void HandleDisconnect(Peer peer)
        {

        }
    }
}
