using System.Text;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Lib.Scripting
{
    internal interface ISpellScriptProvider
    {
        void Initialize(string path);
        ISpellScript ProvideSpellScript(string championModel, string spellName);
    }
}
