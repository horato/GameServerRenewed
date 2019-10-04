using System;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Tests.Base
{
    public class WhereContainerIsAvailable : TestBase
    {
        protected static IUnityContainer Container { get; }

        static WhereContainerIsAvailable()
        {
            Container = new UnityContainer();

            var informationData = new ServerInformationData(DateTime.Now, "TEST_VERSION", TimeSpan.FromSeconds(0.5));
            Container.RegisterInstance<IServerInformationData>(informationData);

            var assemblies = Container.Resolve<IServerInformationData>().GetAllApplicationAssemblies();
            Container.Install(assemblies);
        }
    }
}
