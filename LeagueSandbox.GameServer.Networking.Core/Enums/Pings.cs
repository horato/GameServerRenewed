namespace LeagueSandbox.GameServer.Networking.Core.Enums
{
    public enum Pings : byte
    {
        Default = 0,
        Danger = 2,
        Missing = 3,
        OnMyWay = 4,
        Assist = 6
    }
}