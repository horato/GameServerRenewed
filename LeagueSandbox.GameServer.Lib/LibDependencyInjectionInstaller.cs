using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;
using LeagueSandbox.GameServer.Lib.Maths;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Scripting;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Lib.Services.Compilation;
using LeagueSandbox.GameServer.Lib.Services.Update;
using Unity;

namespace LeagueSandbox.GameServer.Lib
{
    public class LibDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterSingleton<IGameObjectsCache, GameObjectsCache>();
            container.RegisterSingleton<IPlayerCache, PlayerCache>();
            container.RegisterSingleton<INetworkIdCreationService, NetworkIdCreationService>();
            container.RegisterSingleton<IClientIdCreationService, ClientIdCreationService>();
            container.RegisterType<ICalculationService, CalculationService>();
            container.RegisterType<IMapObjectsProvider, MapObjectsProvider>();
            container.RegisterSingleton<ICharacterDataProvider, CharacterDataProvider>();
            container.RegisterSingleton<ISpellDataProvider, SpellDataProvider>();
            container.RegisterSingleton<IScriptEngine, ScriptEngine>();
            container.RegisterType<ICompilationService, CompilationService>();
            container.RegisterType<ISpellCastHelperService, SpellCastHelperService>();

            RegisterGameObjectUpdateServices(container);
            RegisterUpdateServices(container);
        }

        private void RegisterGameObjectUpdateServices(IUnityContainer container)
        {
            container.RegisterType<IGameUpdateService, GameUpdateService>();
            container.RegisterType<IMissileUpdateService, MissileUpdateService>();
            container.RegisterType<IAttackableUnitUpdateService, AttackableUnitUpdateService>();
            container.RegisterType<IGameObjectUpdateService, GameObjectUpdateService>();
            container.RegisterType<ILevelPropAiUpdateService, LevelPropAiUpdateService>();
            container.RegisterType<INeutralMinionCampUpdateService, NeutralMinionCampUpdateService>();
            container.RegisterType<IObjAiBaseUpdateService, ObjAiBaseUpdateService>();
            container.RegisterType<IObjAiHeroUpdateService, ObjAiHeroUpdateService>();
            container.RegisterType<IObjAiMinionUpdateService, ObjAiMinionUpdateService>();
            container.RegisterType<IObjAnimatedBuildingUpdateService, ObjAnimatedBuildingUpdateService>();
            container.RegisterType<IObjBarracksDampenerUpdateService, ObjBarracksDampenerUpdateService>();
            container.RegisterType<IObjBuildingUpdateService, ObjBuildingUpdateService>();
            container.RegisterType<IObjHqUpdateService, ObjHqUpdateService>();
            container.RegisterType<IObjShopUpdateService, ObjShopUpdateService>();
            container.RegisterType<IObjSpawnPointUpdateService, ObjSpawnPointUpdateService>();
            container.RegisterType<IObjTurretUpdateService, ObjTurretUpdateService>();
        }

        private void RegisterUpdateServices(IUnityContainer container)
        {
            container.RegisterType<IMovementService, MovementService>();
            container.RegisterType<ISpellbookUpdateService, SpellbookUpdateService>();
        }
    }
}
