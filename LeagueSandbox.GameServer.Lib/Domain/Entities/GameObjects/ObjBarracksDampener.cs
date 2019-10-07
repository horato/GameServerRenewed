using System;
using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Map.MapObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjBarracksDampener : ObjAnimatedBuilding, IObjBarracksDampener
    {
        public Lane Lane { get; }
        public IDictionary<int, Vector2> MinionWaypoints { get; }
        public Vector2 SpawnPoint { get; }

        public float FirstMinionSpawnDelay { get; }
        public float WaveSpawnRate { get; }
        public float SingleMinionSpawnDelay { get; }
        public float ExpGivenRadius { get; }
        public float GoldGivenRadius { get; }

        public BarrackState BarrackState { get; }
        public float LastWaweSpawnTime { get; private set; }
        public int WavesCount { get; private set; }
        public BarrackSpawnState BarrackSpawnState { get; private set; }
        public float CurrentMinionSpawnTime { get; private set; }
        public int CurrentWaveMinionCounter { get; private set; }

        //waveTimer
        //waveCounts
        //curSpawnNum    
        //curSpawnTimer
        //isDestroyed
        //InhibitorRespawnTime 
        //InhibitorDestroyed
        //SuperMinionSpawnTime
        //SuperMinionsEnabled
        //BarracksEnabled

        public ObjBarracksDampener(Team team, Vector3 position, IStats stats, uint netId, float visionRadius, float collisionRadius, Lane lane, IDictionary<int, Vector2> minionWaypoints, Vector2 spawnPoint, float expGivenRadius, float goldGivenRadius, float firstMinionSpawnDelay, float waveSpawnRate, float singleMinionSpawnDelay, BarrackState barrackState, int wavesCount, BarrackSpawnState barrackSpawnState)
            : base(team, position, stats, netId, visionRadius, collisionRadius)
        {
            Lane = lane;
            MinionWaypoints = minionWaypoints;
            SpawnPoint = spawnPoint;
            FirstMinionSpawnDelay = firstMinionSpawnDelay;
            WaveSpawnRate = waveSpawnRate;
            SingleMinionSpawnDelay = singleMinionSpawnDelay;
            BarrackState = barrackState;
            WavesCount = wavesCount;
            BarrackSpawnState = barrackSpawnState;
            ExpGivenRadius = expGivenRadius;
            GoldGivenRadius = goldGivenRadius;
            LastWaweSpawnTime = firstMinionSpawnDelay - WaveSpawnRate;
        }

        public void ProgressTimers(float millisecondsDiff)
        {

        }

        public void SpawningStarts()
        {
            if (BarrackState != BarrackState.Alive)
                throw new InvalidOperationException("Invalid barrack state");
            if (BarrackSpawnState != BarrackSpawnState.Waiting)
                throw new InvalidOperationException("Invalid spawn state");

            BarrackSpawnState = BarrackSpawnState.Spawning;
        }

        public void AdvanceTimers(float millisecondsDiff)
        {
            CurrentMinionSpawnTime += millisecondsDiff;
        }

        public void MinionSpawned(int minionNumber)
        {
            CurrentWaveMinionCounter = minionNumber;
            CurrentMinionSpawnTime = 0;
        }

        public void WaveSpawnCompleted(float nextSpawnTime)
        {
            if (BarrackSpawnState != BarrackSpawnState.Spawning)
                throw new InvalidOperationException("Invalid spawn state");

            WavesCount++;
            CurrentWaveMinionCounter = 0;
            LastWaweSpawnTime = nextSpawnTime;
            BarrackSpawnState = BarrackSpawnState.Waiting;
        }
    }
}
