using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal interface IMapFactory
    {
        Map CreateNew(MapType mapId);
    }
}
