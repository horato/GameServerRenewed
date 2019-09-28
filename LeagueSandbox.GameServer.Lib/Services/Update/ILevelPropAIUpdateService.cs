using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal interface ILevelPropAiUpdateService
    {
        void Update(ILevelPropAI levelProp, float millisecondsDiff);
    }
}
