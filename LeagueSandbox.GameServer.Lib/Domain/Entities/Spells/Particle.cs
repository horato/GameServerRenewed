using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class Particle : GameObject, IParticle
    {
        public IObjAiBase Source { get; }
        public IGameObject Target { get; }
        public string Name { get; }
        public string BoneName { get; }
        public float Size { get; }

        public Particle(Team team, Vector3 position, float visionRadius, uint netId, float collisionRadius, IObjAiBase source, IGameObject target, string name, string boneName, float size) : base(team, position, visionRadius, collisionRadius, netId)
        {
            Source = source;
            Target = target;
            Name = name;
            BoneName = boneName;
            Size = size;
        }
    }
}
