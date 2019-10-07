using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Core.Scripting.DTO
{
    public class MinionSpawnResult
    {
        public IObjAiMinion Minion { get; }
        public bool ContinueSpawning { get; }

        public MinionSpawnResult(IObjAiMinion minion, bool continueSpawning)
        {
            Minion = minion;
            ContinueSpawning = continueSpawning;
        }
    }
}
