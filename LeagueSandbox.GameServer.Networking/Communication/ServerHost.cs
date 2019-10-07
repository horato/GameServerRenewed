﻿using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.ENetCS;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication
{
    internal class ServerHost : IServerHost
    {
        private readonly IPacketHandler _packetHandler;
        private readonly IServerInformationData _serverInformationData;
        private Host _server;

        private const int PEER_MTU = 996;

        public ServerHost(IPacketHandler packetHandler, IServerInformationData serverInformationData)
        {
            _packetHandler = packetHandler;
            _serverInformationData = serverInformationData;
        }

        public void InitServer(string host, ushort port)
        {
            var address = IPAddress.Parse(host);
            var addressInt = BitConverter.ToUInt32(address.GetAddressBytes(), 0);

            _server = new Host();
            _server.Create(new Address(addressInt, port), 32, 32, 0, 0);
        }

        public void NetLoop()
        {
            while (_server.Service((int)_serverInformationData.RefreshRate.TotalMilliseconds, out var enetEvent) > 0)
            {
                switch (enetEvent.Type)
                {
                    case EventType.Connect:
                        // Set some defaults
                        enetEvent.Peer.Mtu = PEER_MTU;
                        enetEvent.Data = 0;

                        break;
                    case EventType.Receive:
                        var channel = (Channel)enetEvent.ChannelID;
                        using (enetEvent.Packet)
                            _packetHandler.HandlePacket(enetEvent.Peer, enetEvent.Packet, channel);

                        break;
                    case EventType.Disconnect:
                        _packetHandler.HandleDisconnect(enetEvent.Peer);
                        break;
                }
            }
        }
    }
}
