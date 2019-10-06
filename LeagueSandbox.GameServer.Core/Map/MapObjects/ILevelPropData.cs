namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface ILevelPropData
    {
        string Name { get; }
        string SkinName { get; }
        uint NetId { get; }
    }
}