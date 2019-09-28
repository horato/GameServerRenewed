using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal interface IObjAnimatedBuildingUpdateService
    {
        void Update(IObjAnimatedBuilding animatedBuilding, float millisecondsDiff);
    }
}
