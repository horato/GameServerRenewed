using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Map.MapObjects;

namespace LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects
{
    public interface IObjBarracksDampenerFactory
    {
        IObjBarracksDampener CreateFromMapObject(IMapObject obj, IDictionary<int, Vector2> navPoints, Vector2 spawnPoint, IMapSpawnSettings spawnSettings);
    }
}