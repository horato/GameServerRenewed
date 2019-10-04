using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.MapObjects;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjShopFactory : EntityFactoryBase<ObjShop>, IObjShopFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjShopFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjShop CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();
            var instance = new ObjShop
            (
                obj.ShopData.Team, 
                obj.Position, 
                stats, 
                obj.ShopData.NetId,
                1700,
                0);

            return SetupDependencies(instance);
        }
    }
}
