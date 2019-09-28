using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiTurret : ObjAiBase, IObjAiTurret
    {
        public Lane Lane { get; }
        public TurretPosition TurretPosition { get; }

        public ObjAiTurret(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, Lane lane, TurretPosition turretPosition, ISpellBook spellBook) : base(team, position, stats, netId, skinName, skinId, 1200, spellBook)
        {
            Lane = lane;
            TurretPosition = turretPosition;
        }
    }
}
