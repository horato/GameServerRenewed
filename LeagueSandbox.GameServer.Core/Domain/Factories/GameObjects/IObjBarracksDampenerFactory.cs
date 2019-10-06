using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Map.MapObjects;

namespace LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects
{
    public interface IObjBarracksDampenerFactory
    {
        IObjBarracksDampener CreateFromMapObject(IMapObject obj);
    }
}