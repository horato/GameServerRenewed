using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class ChatServerAction : ServerActionBase<ChatRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGame _game;

        public ChatServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGame game)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _game = game;
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
                default:
                    throw new InvalidOperationException($"Invalid command {command}");
            }

        }
    }
}
