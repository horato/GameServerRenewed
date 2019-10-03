using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal interface IMissileUpdateService
    {
        void Update(IMissile missile, float millisecondsDiff);
    }
}
