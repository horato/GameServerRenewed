using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Scripts.Base;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Scripts.Scripts.Maps._1
{
    public class SummonersRiftMapScript : MapScriptBase
    {
        public override MapType MapType => MapType.SummonersRift;

        public SummonersRiftMapScript(IMapDataProvider mapDataProvider) : base(mapDataProvider)
        {
        }
    }
}
