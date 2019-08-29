using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Config.Startup;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal interface IObjAiHeroFactory
    {
        IObjAiHero CreateFromStartupPlayer(StartupPlayer player);
    }
}