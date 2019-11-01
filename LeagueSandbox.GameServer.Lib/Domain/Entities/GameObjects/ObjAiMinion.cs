using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiMinion : ObjAiBase, IObjAiMinion
    {
        public MinionActionState MinionState { get; private set; }
        public IDictionary<int, Vector2> MinionWaypoints { get; }
        public int CurrentWaypoint { get; private set; }
        public int MaxWaypoint { get; }
        public bool IsLaneMinion { get; }

        //MinionRoamState
        //    CampNumber
        //LeashCounter
        //    LeashedPos
        //LeashedOrientation
        //    GroupPos
        //BarrackSpawn
        //    MinionFlags
        //IsWard

        public ObjAiMinion(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, ISpellBook spellBook, MinionActionState minionState, IDictionary<int, Vector2> minionWaypoints, bool isLaneMinion, ICharacterData characterData) : base(team, position, stats, netId, characterData.PerceptionBubbleRadius, characterData.GameplayCollisionRadius, skinName, skinId, spellBook, characterData)
        {
            MinionState = minionState;
            MinionWaypoints = minionWaypoints;
            MaxWaypoint = minionWaypoints.Keys.Max();
            IsLaneMinion = isLaneMinion;
        }

        public void SpawnCompleted()
        {
            if (MinionState != MinionActionState.Spawned)
                throw new InvalidOperationException("Wrong minion state");

            MinionState = MinionActionState.Moving;
            CurrentWaypoint = MinionWaypoints.Keys.Min();
        }

        public void WaypointReached()
        {
            if (MinionState != MinionActionState.Moving)
                throw new InvalidOperationException("Wrong minion state");

            CurrentWaypoint += 1;
        }

        public bool HasMoreWaypoints()
        {
            return CurrentWaypoint < MaxWaypoint;
        }

        public void DestinationReached()
        {
            if (MinionState != MinionActionState.Moving)
                throw new InvalidOperationException("Wrong minion state");

            MinionState = MinionActionState.DestinationReached;
        }
    }
}
