namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICastDataMissileLine : ICastDataMissile
    {
        bool FollowsTerrainHeight { get; }
        bool Bounces { get; }
        bool UsesAccelerationForBounce { get; }
        bool TrackUnits { get; }
        bool TrackUnitsAndContinues { get; }
        float DelayDestroyAtEndSeconds { get; }
        float TimePulseBetweenCollisionSpellHits { get; }
        bool EndsAtTargetPoint { get; }
    }
}