using Unity;

namespace LeagueSandbox.GameServer.Core.Domain.Factories
{
    public abstract class EntityFactoryBase<T>
    {
        private readonly IUnityContainer _unityContainer;

        protected EntityFactoryBase(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        protected T SetupDependencies(T instance)
        {
            if (instance is INeedDependencies)
                _unityContainer.BuildUp(instance);

            return instance;
        }
    }
}
