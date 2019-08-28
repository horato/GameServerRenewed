using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketReaders;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Packets420
{
	public class PacketsDependencyInjectionInstaller : IDependencyInjectionInstaller
	{
		public void Install(IUnityContainer container)
		{
			container.RegisterType<IPacketReader, PacketReader>();
			container.RegisterType<IPacketReaderProvider, PacketReaderProvider>();
			container.RegisterType<IRequestTranslationService, RequestTranslationService>();
			container.RegisterType<IEnumTranslationService, EnumTranslationService>();
		}
	}
}
