using LeagueSandbox.GameServer.Core.Config.Startup;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects
{
    public interface IObjAiHeroFactory
    {
        IObjAiHero CreateFromStartupPlayer(StartupPlayer player, int clientId);
    }
}