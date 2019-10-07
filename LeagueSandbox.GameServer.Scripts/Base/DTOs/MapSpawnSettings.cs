using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Map.MapObjects;

namespace LeagueSandbox.GameServer.Scripts.Base.DTOs
{
    public class MapSpawnSettings : IMapSpawnSettings
    {
        public float FirstMinionSpawnDelay { get; }
        public float WaveSpawnRate { get; }
        public float SingleMinionSpawnDelay { get; }
        public float ExpGivenRadius { get; }
        public float GoldGivenRadius { get; }

        public MapSpawnSettings(float firstMinionSpawnDelay, float waveSpawnRate, float singleMinionSpawnDelay, float expGivenRadius, float goldGivenRadius)
        {
            FirstMinionSpawnDelay = firstMinionSpawnDelay;
            WaveSpawnRate = waveSpawnRate;
            SingleMinionSpawnDelay = singleMinionSpawnDelay;
            ExpGivenRadius = expGivenRadius;
            GoldGivenRadius = goldGivenRadius;
        }
    }
}
