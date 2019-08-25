using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Communication;
using LeagueSandbox.GameServer.Networking.Communication.Processors;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420.PacketWriters;
using LeagueSandbox.GameServer.Networking.Users;
using Unity;

namespace LeagueSandbox.GameServer.Networking
{
    public class NetworkingDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterSingleton<IUsersCache, UsersCache>();
            container.RegisterType<IPacketHandler, PacketHandler>();
            container.RegisterType<IServerActionProvider, ServerActionProvider>();
            container.RegisterType<IPacketProcessor, PacketProcessor>();
            container.RegisterType<IPacketDefinitionReaderProcessor, PacketDefinitionReaderProcessor>();
            container.RegisterType<IUserProcessor, UserProcessor>();
            container.RegisterType<IServerActionProcessor, ServerActionProcessor>();
            container.RegisterType<IPacketNotifier, PacketNotifier>();
            container.RegisterType<IPacketWriter, PacketWriter>();
        }
    }
}
