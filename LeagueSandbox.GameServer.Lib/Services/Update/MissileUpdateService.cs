using System;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class MissileUpdateService : IMissileUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;

        public MissileUpdateService(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGameObjectsCache gameObjectsCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _gameObjectsCache = gameObjectsCache;
        }

        public void Update(IMissile missile, float millisecondsDiff)
        {
            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
            switch (missile.MissileState)
            {
                case MissileState.Created:
                    _packetNotifier.NotifyMissileReplication(targetSummonerIds, missile);
                    missile.MissileLaunched();
                    break;
                case MissileState.Traveling:
                    UpdateMissileLocation(missile, millisecondsDiff);
                    break;
                case MissileState.Arrived:
                    _gameObjectsCache.Remove(missile.NetId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateMissileLocation(IMissile missile, float millisecondsDiff)
        {
            //TODO: missile movement
        }
    }
}