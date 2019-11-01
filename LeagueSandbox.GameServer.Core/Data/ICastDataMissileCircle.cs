namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICastDataMissileCircle : ICastDataMissile
    {
        float RadialVelocity { get; }
        float AngularVelocity { get; }
    }
}