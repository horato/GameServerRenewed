using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services
{
    public interface IMovementService
    {
        void MoveObject(IObjAiBase gameObject, float millisecondsDiff);

        /// <summary> Moves game object. Returns whether destination is reached or not </summary>
        bool MoveObject(IGameObject gameObject, Vector2 to, float movementSpeed, float millisecondsDiff);
    }
}
