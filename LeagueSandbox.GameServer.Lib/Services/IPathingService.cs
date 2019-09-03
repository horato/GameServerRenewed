using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Services
{
    public interface IPathingService
    {
        void Initialize(MapType mapId);

        /// <summary> Finds path between start and destination from map coordinates. Result doesn't include starting position. </summary>
        IEnumerable<Vector2> FindPath(Vector2 start, Vector2 destination);

        Vector2 GetMapCenter();
    }
}