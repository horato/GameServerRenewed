namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IGame
    {
        IMap Map { get; }
        bool IsPaused { get; }
        float GameTimeElapsed { get; }

        void Pause();
        void UnPause();
        void ApplyGameTimeDiff(float diff);
    }
}
