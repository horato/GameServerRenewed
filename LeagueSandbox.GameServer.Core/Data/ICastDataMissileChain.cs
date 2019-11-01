namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICastDataMissileChain : ICastDataMissile
    {
        float BounceRadius { get; }
    }
}