using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal interface IGameFactory
    {
        IGame CreateNew(IMap map);
    }
}
