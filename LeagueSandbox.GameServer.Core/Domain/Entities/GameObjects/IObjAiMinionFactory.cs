using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting.DTO;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiMinionFactory
    {
        IObjAiMinion CreateFromMinionInfo(IObjBarracksDampener barrack, string name, MinionInfo info);
        IObjAiMinion CreateFromCharacterData(ICharacterData data, Team team, Vector3 position, IDictionary<int, Vector2> waypoints, bool isLaneMinion);
    }
}