using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueSandbox.GameServer.Lib.Tests.Tests.Domain.Entities
{
    [TestClass]
    public class GameTests : WhereContainerIsAvailable
    {
        [TestMethod]
        public void Pause_CorrectSettings_Test()
        {
            var game = new GameBuilder().WithIsPaused(false).Build();
            Assert.AreEqual(false, game.IsPaused);

            game.Pause();

            Assert.AreEqual(true, game.IsPaused);
        }

        [TestMethod]
        public void Pause_InvalidSettings_Test()
        {
            var game = new GameBuilder().WithIsPaused(true).Build();
            Assert.AreEqual(true, game.IsPaused);

            var failed = false;
            try
            {
                game.Pause();
            }
            catch (InvalidOperationException)
            {
                failed = true;
            }

            Assert.AreEqual(true, failed);
            Assert.AreEqual(true, game.IsPaused);
        }

        [TestMethod]
        public void UnPause_CorrectSettings_Test()
        {
            var game = new GameBuilder().WithIsPaused(true).Build();
            Assert.AreEqual(true, game.IsPaused);

            game.UnPause();

            Assert.AreEqual(false, game.IsPaused);
        }

        [TestMethod]
        public void UnPause_InvalidSettings_Test()
        {
            var game = new GameBuilder().WithIsPaused(false).Build();
            Assert.AreEqual(false, game.IsPaused);

            var failed = false;
            try
            {
                game.UnPause();
            }
            catch (InvalidOperationException)
            {
                failed = true;
            }

            Assert.AreEqual(true, failed);
            Assert.AreEqual(false, game.IsPaused);
        }

    }
}
