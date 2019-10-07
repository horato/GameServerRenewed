using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
using LeagueSandbox.GameServer.Scripts.Base;
using LeagueSandbox.GameServer.Scripts.Base.DTOs;
using LeagueSandbox.GameServer.Utils.Providers;
using MoreLinq;

namespace LeagueSandbox.GameServer.Scripts.Scripts.Maps._1
{
    public class SummonersRiftMapScript : MapScriptBase
    {
        public override MapType MapType => MapType.SummonersRift;

        private const int MAX_MINIONS_EVER = 180;
        private const int FIRST_MINION_SPAWN_DELAY = 90000;
        private const int WAVE_SPAWN_RATE = 30000;
        private const int SINGLE_MINION_SPAWN_DELAY = 800;
        private const int EXP_GIVEN_RADIUS = 1400;
        private const int GOLD_GIVEN_RADIUS = 1250;
        private const int CANNON_MINION_SPAWN_FREQUENCY = 3;

        private static readonly MinionInfo MeleeDefaultMinionInfo = new MinionInfo(3, 0, 1, 0, 0.625f, 0, 10, 0, 0, 0.5f, 0, 64, 0, 0, 0, 18.8f, 0, 0.2f, 0, 0, 0, 12, 0, 0);
        private static readonly MinionInfo CasterDefaultMinionInfo = new MinionInfo(3, 0, 0.625f, 0, 1, 0, 7.5f, 0, 0, 1, 0, 32, 0, 0, 0, 13.8f, 0, 0.2f, 0, 0, 0, 8, 0, 0);
        private static readonly MinionInfo CannonDefaultMinionInfo = new MinionInfo(0, 0, 1.5f, 0, 1.5f, 0, 13.5f, 0, 0, 1.5f, 0, 100, 0, 0, 0, 39.5f, 0, 0.5f, 0, 0, 0, 30, 0, 0);
        private static readonly MinionInfo SuperDefaultMinionInfo = new MinionInfo(0, 0, 0, 0, 0, 0, 100, 0, 0, 5, 0, 100, 0, 0, 0, 39.5f, 0, 0.5f, 0, 0, 0, 30, 0, 0);

        private static readonly NamedMinionInfo OrderMeleeMinionInfo = new NamedMinionInfo("Blue_Minion_Basic", MinionType.Melee, Team.Blue, MeleeDefaultMinionInfo);
        private static readonly NamedMinionInfo ChaosMeleeMinionInfo = new NamedMinionInfo("Red_Minion_Basic", MinionType.Melee, Team.Red, MeleeDefaultMinionInfo);
        private static readonly NamedMinionInfo OrderCasterMinionInfo = new NamedMinionInfo("Blue_Minion_Wizard", MinionType.Caster, Team.Blue, CasterDefaultMinionInfo);
        private static readonly NamedMinionInfo ChaosCasterMinionInfo = new NamedMinionInfo("Red_Minion_Wizard", MinionType.Caster, Team.Red, CasterDefaultMinionInfo);
        private static readonly NamedMinionInfo OrderCannonMinionInfo = new NamedMinionInfo("Blue_Minion_MechCannon", MinionType.Cannon, Team.Blue, CannonDefaultMinionInfo);
        private static readonly NamedMinionInfo ChaosCannonMinionInfo = new NamedMinionInfo("Red_Minion_MechCannon", MinionType.Cannon, Team.Red, CannonDefaultMinionInfo);
        private static readonly NamedMinionInfo OrderSuperMinionInfo = new NamedMinionInfo("Blue_Minion_MechMelee", MinionType.Super, Team.Blue, SuperDefaultMinionInfo);
        private static readonly NamedMinionInfo ChaosSuperMinionInfo = new NamedMinionInfo("Red_Minion_MechMelee", MinionType.Super, Team.Red, SuperDefaultMinionInfo);

        private static readonly MinionInfoTable DefaultOrderMinionInfoTable = new MinionInfoTable(OrderMeleeMinionInfo, OrderCasterMinionInfo, OrderCannonMinionInfo, OrderSuperMinionInfo);
        private static readonly MinionInfoTable DefaultChaosMinionInfoTable = new MinionInfoTable(ChaosMeleeMinionInfo, ChaosCasterMinionInfo, ChaosCannonMinionInfo, ChaosSuperMinionInfo);

        private static readonly IDictionary<int, MinionType> DefaultMinionSpawnOrder = new Dictionary<int, MinionType>
        {
            { 1, MinionType.Super },
            { 2, MinionType.Melee },
            { 3, MinionType.Cannon },
            { 4, MinionType.Caster }
        };

        private static readonly BarrackInfo DefaultBarrackInfo = new BarrackInfo(false, 0, 0, DefaultMinionSpawnOrder);

        private static readonly TeamBarrackInfo OrderBarrack0 = new TeamBarrackInfo(Lane.Bottom, Team.Blue, DefaultBarrackInfo, DefaultOrderMinionInfoTable);
        private static readonly TeamBarrackInfo OrderBarrack1 = new TeamBarrackInfo(Lane.Middle, Team.Blue, DefaultBarrackInfo, DefaultOrderMinionInfoTable);
        private static readonly TeamBarrackInfo OrderBarrack2 = new TeamBarrackInfo(Lane.Top, Team.Blue, DefaultBarrackInfo, DefaultOrderMinionInfoTable);
        private static readonly TeamBarrackInfo ChaosBarrack0 = new TeamBarrackInfo(Lane.Bottom, Team.Red, DefaultBarrackInfo, DefaultChaosMinionInfoTable);
        private static readonly TeamBarrackInfo ChaosBarrack1 = new TeamBarrackInfo(Lane.Middle, Team.Red, DefaultBarrackInfo, DefaultChaosMinionInfoTable);
        private static readonly TeamBarrackInfo ChaosBarrack2 = new TeamBarrackInfo(Lane.Top, Team.Red, DefaultBarrackInfo, DefaultChaosMinionInfoTable);

        private static readonly IDictionary<Lane, TeamBarrackInfo> OrderBarracks = new Dictionary<Lane, TeamBarrackInfo>
        {
            { Lane.Top, OrderBarrack2 },
            { Lane.Middle, OrderBarrack1 },
            { Lane.Bottom, OrderBarrack0 }
        };

        private static readonly IDictionary<Lane, TeamBarrackInfo> ChaosBarracks = new Dictionary<Lane, TeamBarrackInfo>
        {
            { Lane.Top, ChaosBarrack2 },
            { Lane.Middle, ChaosBarrack1 },
            { Lane.Bottom, ChaosBarrack0 }
        };

        private static readonly int BarracksCount = OrderBarracks.Count + ChaosBarracks.Count;

        private static readonly IDictionary<Team, IDictionary<Lane, TeamBarrackInfo>> BarracksMap = new Dictionary<Team, IDictionary<Lane, TeamBarrackInfo>>
        {
            { Team.Blue, OrderBarracks },
            { Team.Red, ChaosBarracks }
        };

        public SummonersRiftMapScript(IMapDataProvider mapDataProvider, IObjShopFactory shopFactory, IObjBarracksDampenerFactory barracksDampenerFactory, IObjHQFactory hqFactory, IObjAiTurretFactory turretFactory, ILevelPropAIFactory levelPropAiFactory, IGameObjectsCache gameObjectsCache, IObjAiMinionFactory minionFactory) : base(mapDataProvider, shopFactory, barracksDampenerFactory, hqFactory, turretFactory, levelPropAiFactory, gameObjectsCache, minionFactory)
        {
        }

        protected override MapSpawnSettings CreateMapSpawnSettings()
        {
            return new MapSpawnSettings(FIRST_MINION_SPAWN_DELAY, WAVE_SPAWN_RATE, SINGLE_MINION_SPAWN_DELAY, EXP_GIVEN_RADIUS, GOLD_GIVEN_RADIUS);
        }


        private protected override NamedMinionInfo GetMinionSpawnInfo(Lane lane, Team team, int waveNumber, int minionNumber)
        {
            var teamBarrackInfo = BarracksMap[team][lane];
            var meleeMinionCount = teamBarrackInfo.MinionInfoTable.Melee.Info.DefaultNumPerWave;
            var casterMinionCount = teamBarrackInfo.MinionInfoTable.Caster.Info.DefaultNumPerWave;
            var superMinionCount = teamBarrackInfo.MinionInfoTable.Super.Info.DefaultNumPerWave;
            var cannonMinionCount = teamBarrackInfo.MinionInfoTable.Cannon.Info.DefaultNumPerWave;

            if (waveNumber > 0 && waveNumber % CANNON_MINION_SPAWN_FREQUENCY == 0)
                cannonMinionCount++;

            //TODO: enemy barrack death
            //if (teamBarrackInfo.Info.WillSpawnSuperMinion == 1)
            //{
            //    if (team == Team.Blue && totalNumberOfChaosBarracks == 0 || team == Team.Red && totalNumberOfOrderBarracks == 0)
            //        superMinionCount = 2;
            //    else
            //        superMinionCount = 1;

            //    superMinionCount = 0;
            //}

            var currentMinionCounter = 0;
            var minionTypeOrder = teamBarrackInfo.Info.SpawnOrder.OrderBy(x => x.Key).Select(x => x.Value);
            foreach (var minionType in minionTypeOrder)
            {
                switch (minionType)
                {
                    case MinionType.Super:
                        if (superMinionCount == 0)
                            continue;

                        currentMinionCounter += superMinionCount;
                        break;
                    case MinionType.Melee:
                        if (meleeMinionCount == 0)
                            continue;

                        currentMinionCounter += meleeMinionCount;
                        break;
                    case MinionType.Cannon:
                        if (cannonMinionCount == 0)
                            continue;

                        currentMinionCounter += cannonMinionCount;
                        break;
                    case MinionType.Caster:
                        if (casterMinionCount == 0)
                            continue;

                        currentMinionCounter += casterMinionCount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (minionNumber > currentMinionCounter)
                    continue;

                switch (minionType)
                {
                    case MinionType.Super:
                        return teamBarrackInfo.MinionInfoTable.Super;
                    case MinionType.Melee:
                        return teamBarrackInfo.MinionInfoTable.Melee;
                    case MinionType.Cannon:
                        return teamBarrackInfo.MinionInfoTable.Cannon;
                    case MinionType.Caster:
                        return teamBarrackInfo.MinionInfoTable.Caster;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }
    }
}
