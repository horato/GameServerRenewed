using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Tests.Tests.Domain.Factories
{
    [TestClass]
    public class MapFactoryTests : WhereContainerIsAvailable
    {
        [TestMethod]
        public void CreateNewTest()
        {
            var factory = Container.Resolve<IMapFactory>();

            var mapType = MapType.SummonersRift;
            var map = factory.CreateNew(mapType);

            Assert.IsNotNull(map);
            Assert.AreEqual(mapType, map.Id);
        }
    }
}
