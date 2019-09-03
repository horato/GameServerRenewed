using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Core
{
    public class CoreDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterType<ICoordinatesTranslationService, CoordinatesTranslationService>();
        }
    }
}
