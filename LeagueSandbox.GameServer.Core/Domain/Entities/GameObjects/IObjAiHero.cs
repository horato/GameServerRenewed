namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiHero : IObjAiBase
    {
        /// <summary> ID assigned by app that launched the client (lollauncher) </summary>
        ulong SummonerId { get; }

        /// <summary> ID assigned by server upon connection (NOT NETID!) </summary>
        int ClientId { get; }

        /// <summary> Indicated whether this instance is controlled by bot or player </summary>
        bool IsBot { get; }

        /// <summary> Indicates if this instance is currently controlled by player (= is player connected) </summary>
        bool IsPlayerControlled { get; }
    }
}