namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface IMapSpawnSettings
    {
        float FirstMinionSpawnDelay { get; }
        float WaveSpawnRate { get; }
        float SingleMinionSpawnDelay { get; }
        float ExpGivenRadius { get; }
        float GoldGivenRadius { get; }
    }
}