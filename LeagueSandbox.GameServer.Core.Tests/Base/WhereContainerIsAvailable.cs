using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Networking.Packets420;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Tests.Base
{
	public class WhereContainerIsAvailable : TestBase
	{
		protected static IUnityContainer Container { get; }

		static WhereContainerIsAvailable()
		{
			Container = new UnityContainer();

            Container.RegisterType<IServerInformationData, ServerInformationData>();

            var assemblies = Container.Resolve<IServerInformationData>().GetAllApplicationAssemblies();
			Container.Install(assemblies);
		}
	}
}
