namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IGame
    {
        IMap Map { get; }
        bool IsPaused { get; }

        void Pause();
        void UnPause();
    }
}
