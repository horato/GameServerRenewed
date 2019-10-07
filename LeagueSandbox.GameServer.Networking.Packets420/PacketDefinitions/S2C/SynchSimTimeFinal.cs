using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SynchSimTimeFinal : BasePacket
    {
        public float TimeLastClientSeconds { get; }
        public float TimeRttLastOverheadSeconds { get; }
        public float TimeConvergenceSeconds { get; }

        public SynchSimTimeFinal(uint netId, float timeLastClientSeconds, float timeRttLastOverheadSeconds, float timeConvergenceSeconds) : base(PacketCmd.S2CSyncSimTimeFinal, netId)
        {
            TimeLastClientSeconds = timeLastClientSeconds;
            TimeRttLastOverheadSeconds = timeRttLastOverheadSeconds;
            TimeConvergenceSeconds = timeConvergenceSeconds;
        }
    }
}
