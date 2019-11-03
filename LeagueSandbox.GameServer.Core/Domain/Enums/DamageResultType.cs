namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum DamageResultType : byte
    {
        Invulnerable = 1,
        InvulnerableNoMessage = 2,
        Dodge = 3,
        Critical = 4,
        Normal = 5,
        Miss = 6
    }
}
