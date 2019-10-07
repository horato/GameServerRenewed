using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Scripts.Base.DTOs
{
    internal class BarrackInfo
    {
        public bool IsDestroyed { get; }
        public int NumOfSpawnDisables { get; }
        public int WillSpawnSuperMinion { get; }
        public IDictionary<int, MinionType> SpawnOrder { get; }

        public BarrackInfo(bool isDestroyed, int numOfSpawnDisables, int willSpawnSuperMinion, IDictionary<int, MinionType> spawnOrder)
        {
            IsDestroyed = isDestroyed;
            NumOfSpawnDisables = numOfSpawnDisables;
            WillSpawnSuperMinion = willSpawnSuperMinion;
            SpawnOrder = spawnOrder;
        }
    }
}