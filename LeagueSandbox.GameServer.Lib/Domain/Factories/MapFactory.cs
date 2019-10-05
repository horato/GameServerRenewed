using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Providers;
using MoreLinq.Extensions;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class MapFactory : EntityFactoryBase<Map>, IMapFactory
    {
        private readonly IMapScriptProvider _mapScriptProvider;

        public MapFactory(IUnityContainer unityContainer, IMapScriptProvider mapScriptProvider) : base(unityContainer)
        {
            _mapScriptProvider = mapScriptProvider;
        }

        public Map CreateNew(MapType mapId)
        {
            var mapScript = _mapScriptProvider.ProvideMapScript(mapId);
            var data = mapScript.Initialize();

            var instance = new Map(mapId, data.ExpCurve, mapScript);

            return SetupDependencies(instance);
        }
    }
}