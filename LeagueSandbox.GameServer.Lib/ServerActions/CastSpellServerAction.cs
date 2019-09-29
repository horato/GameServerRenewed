using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Maths;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class CastSpellServerAction : ServerActionBase<CastSpellRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly ISpellInstanceFactory _spellInstanceFactory;
        private readonly ICalculationService _calculationService;
        private readonly IFlatStatModifierFactory _flatStatModifierFactory;
        private readonly IPacketNotifier _packetNotifier;

        public CastSpellServerAction(IPlayerCache playerCache, IGameObjectsCache gameObjectsCache, ISpellInstanceFactory spellInstanceFactory, ICalculationService calculationService, IFlatStatModifierFactory flatStatModifierFactory, IPacketNotifier packetNotifier)
        {
            _playerCache = playerCache;
            _gameObjectsCache = gameObjectsCache;
            _spellInstanceFactory = spellInstanceFactory;
            _calculationService = calculationService;
            _flatStatModifierFactory = flatStatModifierFactory;
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, CastSpellRequest request)
        {
            var champion = _playerCache.GetPlayer(senderSummonerId).Champion;
            if (!champion.CanCast())
                return;

            var spell = champion.SpellBook.GetSpell(request.Slot);

            // Spell cooldown
            if (spell.State != SpellState.Ready)
                return;

            IAttackableUnit targetUnit = null;
            if (request.TargetNetID != 0)
            {
                var target = _gameObjectsCache.GetObject(request.TargetNetID);
                targetUnit = target as IAttackableUnit ?? throw new InvalidOperationException("Invalid spell target"); //TODO: Check if this is valid business case or not
            }

            if (spell.TargetingType == TargetingType.Target)
            {
                if (targetUnit == null)
                    throw new InvalidOperationException("Missing target for targeted spell");

                // Cast range
                var distance = _calculationService.CalculateDistance(champion, targetUnit);
                if (distance > spell.CastRange)
                    return;
            }

            // Mana cost
            var manaCost = _calculationService.CalculateManaCost(spell, champion);
            if (manaCost > champion.Stats.FlatManaPoints.CurrentValue)
                return;

            // Consume mana
            var manaDiff = _calculationService.CalculateManaDifferenceAfterSpellCast(champion, manaCost);
            var modifier = _flatStatModifierFactory.CreateValueModifier(manaDiff);
            champion.Stats.FlatManaPoints.ApplyStatModifier(modifier);

            // Cast
            var spellInstance = _spellInstanceFactory.CreateNew(spell, request.Position, request.EndPosition, targetUnit);
            champion.SpellBook.BeginCasting(spellInstance);

            // Response
            var summonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId);
            _packetNotifier.NotifyCastSpellAns(summonerIds, champion, spellInstance, manaCost);
        }
    }
}
