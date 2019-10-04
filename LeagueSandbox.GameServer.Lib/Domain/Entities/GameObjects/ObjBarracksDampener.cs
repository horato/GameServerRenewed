using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjBarracksDampener : ObjAnimatedBuilding, IObjBarracksDampener
    {
        public Lane Lane { get; }

        //waveTimer
        //waveCounts
        //curSpawnNum    
        //curSpawnTimer
        //waveSpawnInterval 
        //minionSpawnInterval
        //mExperienceRadius 
        //GoldRadius
        //isDestroyed
        //BarrackLane
        //InhibitorRespawnTime 
        //InhibitorDestroyed
        //SuperMinionSpawnTime
        //SuperMinionsEnabled
        //BarracksEnabled
        //state enum _DampenerState

        public ObjBarracksDampener(Team team, Vector3 position, IStats stats, uint netId, float visionRadius, float collisionRadius, Lane lane) : base(team, position, stats, netId, visionRadius, collisionRadius)
        {
            Lane = lane;
        }
    }
}
