using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class NetworkIdCreationService : INetworkIdCreationService
    {
        private volatile int _dwStart = 0x40000000;

        public uint GetNewNetId()
        {
           return unchecked((uint)Interlocked.Increment(ref _dwStart));
        }
    }
}
