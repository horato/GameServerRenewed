using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Scripting;
using Newtonsoft.Json;
using Unity;

namespace LeagueSandbox.GameServer.Utils
{
    public class UtilsDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        static UtilsDependencyInjectionInstaller()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new AbstractConverter<IPassiveData, PassiveData>(),
                    new AbstractConverter<IBaseSpellData, BaseSpellData>(),
                    new AbstractConverter<IAttackData, AttackData>(),
                    new AbstractConverter<ICastData, CastData>(),
                }
            };
        }

        public void Install(IUnityContainer container)
        {
            container.RegisterSingleton<IScriptEngine, ScriptEngine>();
        }
    }
}
