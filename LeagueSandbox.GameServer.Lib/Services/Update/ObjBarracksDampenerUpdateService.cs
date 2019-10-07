using System;
using System.Linq;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class ObjBarracksDampenerUpdateService : IObjBarracksDampenerUpdateService
    {
        private readonly Lazy<IGame> _lazyGame;
        private readonly IPlayerCache _playerCache;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IPacketNotifier _packetNotifier;

        public ObjBarracksDampenerUpdateService(Lazy<IGame> lazyGame, IGameObjectsCache gameObjectsCache, IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _lazyGame = lazyGame;
            _gameObjectsCache = gameObjectsCache;
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        public void Update(IObjBarracksDampener barracksDampener, float millisecondsDiff)
        {
            switch (barracksDampener.BarrackState)
            {
                case BarrackState.Alive:
                    SpawnMinions(barracksDampener, millisecondsDiff);
                    break;
                case BarrackState.Respawning:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SpawnMinions(IObjBarracksDampener barrack, float millisecondsDiff)
        {
            var game = _lazyGame.Value;
            if (game.GameTimeElapsedMilliseconds < barrack.FirstMinionSpawnDelay)
                return;

            var nextSpawnTime = barrack.LastWaweSpawnTime + barrack.WaveSpawnRate;
            if (game.GameTimeElapsedMilliseconds < nextSpawnTime)
                return;

            barrack.AdvanceTimers(millisecondsDiff);
            switch (barrack.BarrackSpawnState)
            {
                case BarrackSpawnState.Waiting:
                    StartSpawn(barrack, nextSpawnTime);
                    break;
                case BarrackSpawnState.Spawning:
                    SpawnNextMinion(barrack, nextSpawnTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartSpawn(IObjBarracksDampener barrack, float nextSpawnTime)
        {
            barrack.SpawningStarts();
            SpawnSingleMinion(barrack, nextSpawnTime);
        }

        private void SpawnNextMinion(IObjBarracksDampener barrack, float nextSpawnTime)
        {
            if (barrack.CurrentMinionSpawnTime < barrack.SingleMinionSpawnDelay)
                return;

            SpawnSingleMinion(barrack, nextSpawnTime);
        }

        private void SpawnSingleMinion(IObjBarracksDampener barrack, float nextSpawnTime)
        {
            var script = _lazyGame.Value.Map.MapScript;
            var minionNumber = barrack.CurrentWaveMinionCounter + 1;
            var result = script.SpawnMinion(minionNumber, barrack);

            if (result.Minion != null)
            {
                _gameObjectsCache.Add(result.Minion.NetId, result.Minion);

                var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); //TODO: vision
                _packetNotifier.NotifyMinionSpawn(targetSummonerIds, result.Minion);
                _packetNotifier.NotifyEnterVisibilityClient(targetSummonerIds, result.Minion);

                barrack.MinionSpawned(minionNumber);
            }
            
            if (!result.ContinueSpawning)
                barrack.WaveSpawnCompleted(nextSpawnTime);
        }
    }
}