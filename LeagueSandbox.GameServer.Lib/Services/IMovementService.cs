using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services
{
    public interface IMovementService
    {
        void MoveObject(IObjAiBase gameObject, float millisecondsDiff);
    }
}
