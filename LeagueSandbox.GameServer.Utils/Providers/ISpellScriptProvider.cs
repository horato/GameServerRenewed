using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface ISpellScriptProvider
    {
        bool SpellScriptExists(string championModel, string spellName);
        ISpellScript ProvideSpellScript(string championModel, string spellName);
    }
}
