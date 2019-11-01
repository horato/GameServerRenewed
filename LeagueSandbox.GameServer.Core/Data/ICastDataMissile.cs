namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICastDataMissile : ICastData
    {
        float Gravity { get; }
        float TargetHeightAugment { get; }
        float Speed { get; }
        float Accel { get; }
        float MaxSpeed { get; }
        float MinSpeed { get; }
        float FixedTravelTime { get; }
        float MinTravelTime { get; }
        float Lifetime { get; }
        bool Unblockable { get; }
        bool BlockTriggersOnDestroy { get; }
        float PerceptionBubbleRadius { get; }
        bool PerceptionBubbleRevealsStealth { get; }
        float UpdateDistanceInterval { get; }
    }
}