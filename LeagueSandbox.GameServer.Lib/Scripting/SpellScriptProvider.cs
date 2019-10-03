using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Scripts;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Scripting
{
    internal class SpellScriptProvider : ISpellScriptProvider
    {
        private readonly string SPELL_SCRIPT_TYPE_NAME = $"{ScriptsAssemblyDefiningType.Assembly.GetName().Name}." +
                                                         $"{nameof(LeagueSandbox.GameServer.Scripts.Scripts)}." +
                                                         $"{nameof(LeagueSandbox.GameServer.Scripts.Scripts.Champions)}." +
                                                         "{0}." +
                                                         $"{nameof(LeagueSandbox.GameServer.Scripts.Scripts.Champions.Ezreal.Spells)}." +
                                                         "{1}";

        private readonly IScriptEngine _scriptEngine;
        private readonly IUnityContainer _unityContainer;
        private IDictionary<string, Type> _spellScriptsCache = new Dictionary<string, Type>();

        public SpellScriptProvider(IScriptEngine scriptEngine, IUnityContainer unityContainer)
        {
            _scriptEngine = scriptEngine;
            _unityContainer = unityContainer;
        }

        public void Initialize(string path)
        {
            _scriptEngine.LoadScripts(path);
            _spellScriptsCache = _scriptEngine.GetAllScripts().Where(x => typeof(ISpellScript).IsAssignableFrom(x)).Where(x => !x.IsAbstract && !x.IsInterface).ToDictionary(x => x.FullName);
        }

        public bool SpellScriptExists(string championModel, string spellName)
        {
            var typeName = string.Format(SPELL_SCRIPT_TYPE_NAME, championModel, spellName);
            return _spellScriptsCache.ContainsKey(typeName);
        }

        public ISpellScript ProvideSpellScript(string championModel, string spellName)
        {
            var typeName = string.Format(SPELL_SCRIPT_TYPE_NAME, championModel, spellName);
            if (!_spellScriptsCache.ContainsKey(typeName))
                throw new InvalidOperationException($"Spell script {typeName} not found");

            // Creating stateless instance each time. If the need for singleton instances arises, refactor this.
            var type = _spellScriptsCache[typeName];
            var resolvedType = _unityContainer.Resolve(type);
            if (resolvedType == null)
                throw new InvalidOperationException($"Failed to resolve {type}");

            var spellScriptInstance = resolvedType as ISpellScript;
            if (spellScriptInstance == null)
                throw new InvalidOperationException($"Failed to cast type {type} to {nameof(ISpellScript)}");

            return spellScriptInstance;
        }
    }
}