using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal interface ICollisionService
    {
        /// <summary> Finds all attackable objects colliding with <paramref name="gameObject"/> ordered by distance </summary>
        IEnumerable<IGameObject> FindAttackableObjectsCollidingWith(IGameObject gameObject);
    }
}