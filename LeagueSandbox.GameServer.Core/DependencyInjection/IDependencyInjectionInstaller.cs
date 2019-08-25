using Unity;

namespace LeagueSandbox.GameServer.Core.DependencyInjection
{
	public interface IDependencyInjectionInstaller
	{
		void Install(IUnityContainer container);
	}
}
