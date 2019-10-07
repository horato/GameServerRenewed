using LeagueSandbox.GameServer.Core.Scripting.DTO;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiMinionFactory
    {
        IObjAiMinion CreateFromMinionInfo(IObjBarracksDampener barrack, string name, MinionInfo info);
    }
}