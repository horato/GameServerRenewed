using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal interface IObjHQFactory
    {
        IObjHQ CreateFromMapObject(MapObject obj);
    }
}