using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Scripting.DTO
{
    public class MapInitializationData
    {
        public IDictionary<int, float> ExpCurve { get; }

        public MapInitializationData(IDictionary<int, float> expCurve)
        {
            ExpCurve = expCurve;
        }
    }
}
