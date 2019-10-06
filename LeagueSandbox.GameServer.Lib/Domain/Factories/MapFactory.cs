using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Providers;
using MoreLinq.Extensions;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class MapFactory : EntityFactoryBase<Map>, IMapFactory
    {
        public MapFactory(IUnityContainer unityContainer) : base(unityContainer)
        {

        }

        public Map CreateFromMapInitializationData(MapInitializationData data)
        {
            var instance = new Map(data.MapType, data.ExpCurve, data.MapScript);

            return SetupDependencies(instance);
        }
    }
}