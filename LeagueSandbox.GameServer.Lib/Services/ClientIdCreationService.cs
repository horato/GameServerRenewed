using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class ClientIdCreationService : IClientIdCreationService
    {
        private volatile int _dwStart = -1;

        public int GetNewId()
        {
           return Interlocked.Increment(ref _dwStart);
        }
    }
}
