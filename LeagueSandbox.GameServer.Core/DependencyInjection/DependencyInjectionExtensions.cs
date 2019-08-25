using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;

namespace LeagueSandbox.GameServer.Core.DependencyInjection
{
	public static class DependencyInjectionExtensions
	{
		public static void Install(this IUnityContainer container, IEnumerable<Assembly> assemblies)
		{
			foreach (var assembly in assemblies)
			{
				var installers = assembly.GetTypes().Where(x => typeof(IDependencyInjectionInstaller).IsAssignableFrom(x)).Where(x => !x.IsAbstract && !x.IsInterface);
				foreach (var installer in installers)
				{
					var instance = container.Resolve(installer) as IDependencyInjectionInstaller;
					instance.Install(container);
				}
			}
		}
	}
}
