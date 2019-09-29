using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpellInstance
    {
        ISpell Definition { get; }
        SpellInstanceState State { get; }
        float CastTimeRemaining { get; }
        float ChannelTimeRemaining { get; }
        Vector2 StartPosition { get; }
        Vector2 EndPosition { get; }
        IAttackableUnit Target { get; }
        uint FutureProjectileNetId { get; }
        uint InstanceNetId { get; }

        void CastingStart();
        void CastingProgress(float secondsDiff);
        void ChannelingStart();
        void ChannelingProgress(float secondsDiff);
        void CastingFinished();
    }
}