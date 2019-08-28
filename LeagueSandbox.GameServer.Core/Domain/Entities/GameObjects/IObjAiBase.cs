namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiBase : IAttackableUnit
    {
        string SkinName { get; }
        int SkinId { get; }
    }
}