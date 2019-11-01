using LeagueSandbox.GameServer.Core.Data;
using Newtonsoft.Json;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    [JsonConverter(typeof(CastDataConverter))]
    public abstract class CastData : ICastData
    {
        public abstract Core.Domain.Enums.CastType CastType { get; }

        private CastData()
        {

        }

        public sealed class Instant : CastData, ICastDataInstant
        {
            public override Core.Domain.Enums.CastType CastType => Core.Domain.Enums.CastType.Instant;

            public Instant()
            {

            }
        }

        public abstract class Missile : CastData, ICastDataMissile
        {
            public float Gravity { get; }
            public float TargetHeightAugment { get; }
            public float Speed { get; }
            public float Accel { get; }
            public float MaxSpeed { get; }
            public float MinSpeed { get; }
            public float FixedTravelTime { get; }
            public float MinTravelTime { get; }
            public float Lifetime { get; }
            public bool Unblockable { get; }
            public bool BlockTriggersOnDestroy { get; }
            public float PerceptionBubbleRadius { get; }
            public bool PerceptionBubbleRevealsStealth { get; }
            public float UpdateDistanceInterval { get; }

            protected Missile(float gravity, float targetHeightAugment, float speed, float accel, float maxSpeed, float minSpeed, float fixedTravelTime, float minTravelTime, float lifetime, bool unblockable, bool blockTriggersOnDestroy, float perceptionBubbleRadius, bool perceptionBubbleRevealsStealth, float updateDistanceInterval)
            {
                Gravity = gravity;
                TargetHeightAugment = targetHeightAugment;
                Speed = speed;
                Accel = accel;
                MaxSpeed = maxSpeed;
                MinSpeed = minSpeed;
                FixedTravelTime = fixedTravelTime;
                MinTravelTime = minTravelTime;
                Lifetime = lifetime;
                Unblockable = unblockable;
                BlockTriggersOnDestroy = blockTriggersOnDestroy;
                PerceptionBubbleRadius = perceptionBubbleRadius;
                PerceptionBubbleRevealsStealth = perceptionBubbleRevealsStealth;
                UpdateDistanceInterval = updateDistanceInterval;
            }

            public sealed class Normal : Missile, ICastDataMissileNormal
            {
                public override Core.Domain.Enums.CastType CastType => Core.Domain.Enums.CastType.Missile;

                public Normal(float gravity, float targetHeightAugment, float speed, float accel, float maxSpeed, float minSpeed, float fixedTravelTime, float minTravelTime, float lifetime, bool unblockable, bool blockTriggersOnDestroy, float perceptionBubbleRadius, bool perceptionBubbleRevealsStealth, float updateDistanceInterval) : base(gravity, targetHeightAugment, speed, accel, maxSpeed, minSpeed, fixedTravelTime, minTravelTime, lifetime, unblockable, blockTriggersOnDestroy, perceptionBubbleRadius, perceptionBubbleRevealsStealth, updateDistanceInterval)
                {
                }
            }

            public sealed class Line : Missile, ICastDataMissileLine
            {
                public override Core.Domain.Enums.CastType CastType => Core.Domain.Enums.CastType.ArcMissile;
                public bool FollowsTerrainHeight { get; }
                public bool Bounces { get; }
                public bool UsesAccelerationForBounce { get; }
                public bool TrackUnits { get; }
                public bool TrackUnitsAndContinues { get; }
                public float DelayDestroyAtEndSeconds { get; }
                public float TimePulseBetweenCollisionSpellHits { get; }
                public bool EndsAtTargetPoint { get; }

                public Line(float gravity, float targetHeightAugment, float speed, float accel, float maxSpeed, float minSpeed, float fixedTravelTime, float minTravelTime, float lifetime, bool unblockable, bool blockTriggersOnDestroy, float perceptionBubbleRadius, bool perceptionBubbleRevealsStealth, float updateDistanceInterval, bool followsTerrainHeight, bool bounces, bool usesAccelerationForBounce, bool trackUnits, bool trackUnitsAndContinues, float delayDestroyAtEndSeconds, float timePulseBetweenCollisionSpellHits, bool endsAtTargetPoint) : base(gravity, targetHeightAugment, speed, accel, maxSpeed, minSpeed, fixedTravelTime, minTravelTime, lifetime, unblockable, blockTriggersOnDestroy, perceptionBubbleRadius, perceptionBubbleRevealsStealth, updateDistanceInterval)
                {
                    FollowsTerrainHeight = followsTerrainHeight;
                    Bounces = bounces;
                    UsesAccelerationForBounce = usesAccelerationForBounce;
                    TrackUnits = trackUnits;
                    TrackUnitsAndContinues = trackUnitsAndContinues;
                    DelayDestroyAtEndSeconds = delayDestroyAtEndSeconds;
                    TimePulseBetweenCollisionSpellHits = timePulseBetweenCollisionSpellHits;
                    EndsAtTargetPoint = endsAtTargetPoint;
                }
            }

            public sealed class Chain : Missile, ICastDataMissileChain
            {
                public override Core.Domain.Enums.CastType CastType => Core.Domain.Enums.CastType.ChainMissile;
                public float BounceRadius { get; }

                public Chain(float gravity, float targetHeightAugment, float speed, float accel, float maxSpeed, float minSpeed, float fixedTravelTime, float minTravelTime, float lifetime, bool unblockable, bool blockTriggersOnDestroy, float perceptionBubbleRadius, bool perceptionBubbleRevealsStealth, float updateDistanceInterval, float bounceRadius) : base(gravity, targetHeightAugment, speed, accel, maxSpeed, minSpeed, fixedTravelTime, minTravelTime, lifetime, unblockable, blockTriggersOnDestroy, perceptionBubbleRadius, perceptionBubbleRevealsStealth, updateDistanceInterval)
                {
                    BounceRadius = bounceRadius;
                }
            }

            public sealed class Circle : Missile, ICastDataMissileCircle
            {
                public override Core.Domain.Enums.CastType CastType => Core.Domain.Enums.CastType.CircleMissile;
                public float RadialVelocity { get; }
                public float AngularVelocity { get; }

                public Circle(float gravity, float targetHeightAugment, float speed, float accel, float maxSpeed, float minSpeed, float fixedTravelTime, float minTravelTime, float lifetime, bool unblockable, bool blockTriggersOnDestroy, float perceptionBubbleRadius, bool perceptionBubbleRevealsStealth, float updateDistanceInterval, float radialVelocity, float angularVelocity) : base(gravity, targetHeightAugment, speed, accel, maxSpeed, minSpeed, fixedTravelTime, minTravelTime, lifetime, unblockable, blockTriggersOnDestroy, perceptionBubbleRadius, perceptionBubbleRevealsStealth, updateDistanceInterval)
                {
                    RadialVelocity = radialVelocity;
                    AngularVelocity = angularVelocity;
                }
            }
        }
    }
}
