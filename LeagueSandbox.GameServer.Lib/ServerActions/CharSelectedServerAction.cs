using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class CharSelectedServerAction : ServerActionBase<CharSelectedRequest>
    {
        private static readonly ILog Log = LoggerProvider.GetLogger();

        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IGameObjectsCache _gameObjectsCache;

        public CharSelectedServerAction(IPlayerCache playerCache, IPacketNotifier packetNotifier, IGameObjectsCache gameObjectsCache)
        {
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
            _gameObjectsCache = gameObjectsCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, CharSelectedRequest request)
        {
            Log.Debug("Spawning map");

            var players = _playerCache.GetAllPlayers();
            var blueBots = 0;
            var redBots = 0;
            foreach (var player in players)
            {
                if (!player.Champion.IsBot)
                    continue;

                switch (player.Champion.Team)
                {
                    case Team.Blue:
                        blueBots++;
                        break;
                    case Team.Red:
                        redBots++;
                        break;
                    case Team.Neutral:
                        throw new InvalidOperationException("Bots shouldn't be neutral.");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var sender = _playerCache.GetPlayer(senderSummonerId);
            _packetNotifier.NotifyStartSpawn(senderSummonerId, blueBots, redBots);
            
            //TODO: inventory; Might also load this during champion creation. Blue pill is map based
            //var bluePill = _itemManager.GetItemType(_game.Map.MapProperties.BluePillId);
            //var itemInstance = peerInfo.Champion.Inventory.SetExtraItem(7, bluePill);

            // self-inform
            _packetNotifier.NotifyCreateHero(senderSummonerId, sender);
            _packetNotifier.NotifyAvatarInfo(senderSummonerId, sender);
            
            //_packetNotifier.NotifyBuyItem(userId, peerInfo.Champion, itemInstance); //TODO: Is this necessary? CreateHero already sends items

            //TODO: runes - although this could easily be applied on champion creation. In fact, this might even be bug. More reconnects = more stats.
            //// Runes
            //byte runeItemSlot = 14;
            //foreach (var rune in peerInfo.Champion.RuneList.Runes)
            //{
            //    var runeItem = _itemManager.GetItemType(rune.Value);
            //    var newRune = peerInfo.Champion.Inventory.SetExtraItem(runeItemSlot, runeItem);
            //    _playerManager.GetPeerInfo((ulong)userId).Champion.Stats.AddModifier(runeItem);
            //    runeItemSlot++;
            //}

            //TODO: (Summoner)Spells; Also this recall thing is fishy
            // Not sure why both 7 and 14 skill slot, but it does not seem to work without it
            //_packetNotifier.NotifySkillUp(userId, peerInfo.Champion.NetId, 7, 1, peerInfo.Champion.SkillPoints);
            //_packetNotifier.NotifySkillUp(userId, peerInfo.Champion.NetId, 14, 1, peerInfo.Champion.SkillPoints);

            //peerInfo.Champion.Stats.SetSpellEnabled(7, true);
            //peerInfo.Champion.Stats.SetSpellEnabled(14, true);
            //peerInfo.Champion.Stats.SetSummonerSpellEnabled(0, true);
            //peerInfo.Champion.Stats.SetSummonerSpellEnabled(1, true);

            //var objects = _gameObjectsCache.GetAllObjects();
            //foreach (var gameObject in objects)
            //{
            //    if (gameObject is IObjAiTurret turret)
            //    {
            //        _packetNotifier.NotifyTurretSpawn(userId, turret);

            //        // Fog Of War
            //        _packetNotifier.NotifyFogUpdate2(turret, _networkIdManager.GetNewNetId());

            //        // To suppress game HP-related errors for enemy turrets out of vision
            //        _packetNotifier.NotifyEnterLocalVisibilityClient(turret, userId);

            //        foreach (var item in turret.Inventory)
            //        {
            //            if (item == null)
            //            {
            //                continue;
            //            }

            //            _packetNotifier.NotifyBuyItem((int)turret.NetId, turret, item as IItem);
            //        }
            //    }
            //    else if (kv.Value is ILevelProp levelProp)
            //    {
            //        _packetNotifier.NotifyLevelPropSpawn(userId, levelProp);
            //    }
            //    else if (kv.Value is IChampion champion)
            //    {
            //        if (champion.IsVisibleByTeam(peerInfo.Champion.Team))
            //        {
            //            _packetNotifier.NotifyEnterVisibilityClient(champion, champion.Team, userId);
            //        }
            //    }
            //    else if (kv.Value is IInhibitor || kv.Value is INexus)
            //    {
            //        var inhibtor = (IAttackableUnit)kv.Value;
            //        _packetNotifier.NotifyStaticObjectSpawn(userId, inhibtor.NetId);
            //        _packetNotifier.NotifyEnterLocalVisibilityClient(userId, inhibtor.NetId);
            //    }
            //    else if (kv.Value is IProjectile projectile)
            //    {
            //        if (projectile.IsVisibleByTeam(peerInfo.Champion.Team))
            //        {
            //            _packetNotifier.NotifyProjectileSpawn(userId, projectile);
            //        }
            //    }
            //    else
            //    {
            //        _logger.Warn("Object of type: " + kv.Value.GetType() + " not handled in HandleSpawn.");
            //    }
            //}

            //// TODO shop map specific?
            //// Level props are just models, we need button-object minions to allow the client to interact with it
            //// TODO: Generate shop NetId to avoid hard-coding
            //if (peerInfo != null && peerInfo.Team == TeamId.TEAM_BLUE)
            //{
            //    // Shop (blue team)
            //    _packetNotifier.NotifyStaticObjectSpawn(userId, 0xff10c6db);
            //    _packetNotifier.NotifyEnterLocalVisibilityClient(userId, 0xff10c6db);
            //}
            //else if (peerInfo != null && peerInfo.Team == TeamId.TEAM_PURPLE)
            //{
            //    // Shop (purple team)
            //    _packetNotifier.NotifyStaticObjectSpawn(userId, 0xffa6170e);
            //    _packetNotifier.NotifyEnterLocalVisibilityClient(userId, 0xffa6170e);
            //}

            _packetNotifier.NotifyEndSpawn(senderSummonerId);
        }
    }
}
