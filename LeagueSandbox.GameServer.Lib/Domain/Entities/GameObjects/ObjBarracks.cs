using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjBarracks : ObjBuilding, IObjBarracks
    {
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
        //Lane

        public ObjBarracks(Team team, Vector3 position, IStats stats, uint netId) : base(team, position, stats, netId)
        {
        }
    }
}
