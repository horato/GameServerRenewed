using System.Text;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Lib.Scripting
{
    internal interface ISpellScriptProvider
    {
        void Initialize(string path);
        bool SpellScriptExists(string championModel, string spellName);
        ISpellScript ProvideSpellScript(string championModel, string spellName);
    }
}
