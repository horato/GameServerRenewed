using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjBarracksDampener : IObjAnimatedBuilding
    {
        Lane Lane { get; }
        IDictionary<int, Vector2> MinionWaypoints { get; }
        Vector2 SpawnPoint { get; }
        float FirstMinionSpawnDelay { get; }
        float WaveSpawnRate { get; }
        float SingleMinionSpawnDelay { get; }
        float ExpGivenRadius { get; }
        float GoldGivenRadius { get; }
        BarrackState BarrackState { get; }
        float LastWaweSpawnTime { get; }
        int WavesCount { get; }
        BarrackSpawnState BarrackSpawnState { get; }

        /// <summary> Counter for delay between each minion spawn. Resets with each spawned minion. </summary>
        float CurrentMinionSpawnTime { get; }

        /// <summary> Number of spawned minions in current wave </summary>
        int CurrentWaveMinionCounter { get; }
        
        void ProgressTimers(float millisecondsDiff);
        void SpawningStarts();
        void AdvanceTimers(float millisecondsDiff);
        void MinionSpawned(int minionNumber);
        void WaveSpawnCompleted(float nextSpawnTime);
    }
}