using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal interface IObjAiHeroUpdateService
    {
        void Update(IObjAiHero hero, float millisecondsDiff);
    }
}
