using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Tests.Tests.Domain.Factories
{
    [TestClass]
    public class GameFactoryTests : WhereContainerIsAvailable
    {
        [TestMethod]
        public void CreateNewTest()
        {
            var factory = Container.Resolve<IGameFactory>();
            var map = new MapBuilder().Build();

            var game = factory.CreateNew(map);

            Assert.IsNotNull(game);
            Assert.AreEqual(map, game.Map);
            Assert.AreEqual(true, game.IsPaused);
        }
    }
}
