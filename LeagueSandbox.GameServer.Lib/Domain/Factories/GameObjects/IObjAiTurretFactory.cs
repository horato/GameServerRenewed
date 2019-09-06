using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Utils.MapObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal interface IObjAiTurretFactory
    {
        IObjAiTurret CreateFromMapObject(MapObject obj);
    }
}