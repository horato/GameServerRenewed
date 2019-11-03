﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class ChatServerAction : ServerActionBase<ChatRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGame _game;
        private readonly ICharacterDataProvider _characterDataProvider;
        private readonly IObjAiMinionFactory _minionFactory;
        private readonly IGameObjectsCache _gameObjectsCache;

        public ChatServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGame game, ICharacterDataProvider characterDataProvider, IGameObjectsCache gameObjectsCache, IObjAiMinionFactory minionFactory)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _game = game;
            _characterDataProvider = characterDataProvider;
            _gameObjectsCache = gameObjectsCache;
            _minionFactory = minionFactory;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, ChatRequest request)
        {
            var sender = _playerCache.GetPlayer(senderSummonerId);

            if (request.Message.StartsWith("!"))
            {
                //TODO: refactor this
                ProcessCommand(sender, request.Message);
                return;
            }

            var targetSummonerIds = _playerCache.GetAllPlayers().Where(x => request.ChatType != ChatType.Team || x.Champion.Team == sender.Champion.Team).Select(x => x.SummonerId);
            _packetNotifier.NotifyChatMessage(targetSummonerIds, request.ClientID, request.NetID, request.Localized, request.ChatType, request.Params, request.Message);
        }

        private void ProcessCommand(IPlayer sender, string message)
        {
            var split = message.Split(' ');
            if (split.Length < 1)
                throw new InvalidOperationException("Invalid command");

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId);
            var command = split[0].Replace("!", "");
            switch (command)
            {
                case "simspeed":
                    if (split.Length < 2)
                        throw new InvalidOperationException("Invalid args");

                    var value = float.Parse(split[1]);
                    _game.SetSimSpeed(value);
                    break;
                case "pos":
                    _packetNotifier.NotifyChatMessage(targetSummonerIds, sender.Champion.ClientId, sender.Champion.NetId, false, ChatType.All, string.Empty, $"{sender.Champion.SkinName}: {sender.Champion.Position}");
                    _packetNotifier.NotifyMapPing(targetSummonerIds, sender.Champion.Position.ToVector2(), 0, sender.Champion.NetId, PingCategory.Default, true, true, false, true);
                    break;
                case "spawn":
                    var data = _characterDataProvider.ProvideCharacterData("Red_Minion_Basic");
                    var waypoints = new Dictionary<int, Vector2> { { 0, sender.Champion.Position.ToVector2() } };
                    var minion = _minionFactory.CreateFromCharacterData(data, Team.Red, sender.Champion.Position, waypoints, true);
                    _gameObjectsCache.Add(minion.NetId, minion);
                    _packetNotifier.NotifyMinionSpawn(targetSummonerIds, minion);
                    _packetNotifier.NotifyEnterVisibilityClient(targetSummonerIds, minion);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid command {command}");
            }

        }
    }
}
