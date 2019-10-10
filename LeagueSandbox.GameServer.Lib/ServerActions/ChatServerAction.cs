using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;
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
                ProcessCommand(request.Message);
                return;
            }

            var targetSummonerIds = _playerCache.GetAllPlayers().Where(x => request.ChatType != ChatType.Team || x.Champion.Team == sender.Champion.Team).Select(x => x.SummonerId);
            _packetNotifier.WriteChatMessage(targetSummonerIds, request.ClientID, request.NetID, request.Localized, request.ChatType, request.Params, request.Message);
        }

        private void ProcessCommand(string message)
        {
            var split = message.Split(' ');
            if (split.Length < 1)
                throw new InvalidOperationException("Invalid command");

            var command = split[0].Replace("!", "");
            switch (command)
            {
                case "simspeed":
                    if (split.Length < 2)
                        throw new InvalidOperationException("Invalid args");

                    var value = float.Parse(split[1]);
                    _game.SetSimSpeed(value);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid command {command}");
            }

        }
    }
}
