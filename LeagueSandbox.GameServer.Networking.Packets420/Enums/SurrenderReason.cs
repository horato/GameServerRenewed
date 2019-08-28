namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    public enum SurrenderReason : uint
    {
        Failed = 0,
        TooEarly = 1,
        TooQuickly = 2,
        AlreadyVoted = 3,
        Passed = 4
    }
}