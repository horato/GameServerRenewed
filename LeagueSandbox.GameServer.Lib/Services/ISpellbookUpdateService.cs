using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal interface ISpellbookUpdateService
    {
        void UpdateSpellbook(IObjAiBase obj, float millisecondsDiff);
    }
}
