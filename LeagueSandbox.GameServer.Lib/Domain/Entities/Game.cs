﻿using System;
using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities
{
    internal class Game : IGame
    {
        public IMap Map { get; }
        public bool IsPaused { get; private set; }
        public float GameTimeElapsed { get; private set; }

        public Game(IMap map, bool isPaused, float gameTimeElapsed)
        {
            Map = map ?? throw new ArgumentNullException(nameof(map));
            IsPaused = isPaused;
            GameTimeElapsed = gameTimeElapsed;
        }

        public void Pause()
        {
            if (IsPaused)
                throw new InvalidOperationException("Game is already paused");

            IsPaused = true;
        }

        public void UnPause()
        {
            if (!IsPaused)
                throw new InvalidOperationException("Game is not paused");

            IsPaused = false;
        }

        public void ApplyGameTimeDiff(float diff)
        {
            if(IsPaused)
                throw new InvalidOperationException("Cannot apply time diff while paused");

            GameTimeElapsed += diff;
        }
    }
}
