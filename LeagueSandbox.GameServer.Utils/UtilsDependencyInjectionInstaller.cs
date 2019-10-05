using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Utils.Scripting;
using Unity;

namespace LeagueSandbox.GameServer.Utils
{
    public class UtilsDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterSingleton<IScriptEngine, ScriptEngine>();
        }
    }
}
