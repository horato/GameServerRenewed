using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Utils.Providers;
using LeagueSandbox.GameServer.Utils.Scripting;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class MapScriptProvider : IMapScriptProvider
    {
        private readonly IScriptEngine _scriptEngine;
        private readonly IUnityContainer _unityContainer;
        private readonly IDictionary<MapType, IMapScript> _spellScriptsCache = new Dictionary<MapType, IMapScript>();

        public MapScriptProvider(IScriptEngine scriptEngine, IUnityContainer unityContainer)
        {
            _scriptEngine = scriptEngine;
            _unityContainer = unityContainer;
            Initialize();
        }

        private void Initialize()
        {
            var mapScriptTypes = _scriptEngine.GetAllScripts().Where(x => typeof(IMapScript).IsAssignableFrom(x)).Where(x => !x.IsAbstract && !x.IsInterface);
            foreach (var mapScriptType in mapScriptTypes)
            {
                var instance = _unityContainer.Resolve(mapScriptType);
                if (instance == null)
                    throw new InvalidOperationException($"Failed to resolve {mapScriptType}");

                var mapScriptInstance = instance as IMapScript;
                if (mapScriptInstance == null)
                    throw new InvalidOperationException($"Failed to cast type {instance} to {nameof(IMapScript)}");
                if (_spellScriptsCache.ContainsKey(mapScriptInstance.MapType))
                    throw new InvalidOperationException($"Map script for map {mapScriptInstance.MapType} already exists");

                _spellScriptsCache.Add(mapScriptInstance.MapType, mapScriptInstance);
            }
        }

        public IMapScript ProvideMapScript(MapType map)
        {
            if (!_spellScriptsCache.ContainsKey(map))
                throw new InvalidOperationException($"Map script for map {map} not found");

            return _spellScriptsCache[map];
        }
    }
}
