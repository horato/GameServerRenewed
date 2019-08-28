﻿using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain
{
    public class DomainDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterType<IGameFactory, GameFactory>();
            container.RegisterType<IMapFactory, MapFactory>();
        }
    }
}
