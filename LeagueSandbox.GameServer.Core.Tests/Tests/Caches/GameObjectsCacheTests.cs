using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Tests.Tests.Caches
{
    /// <summary>
    /// IGameObjectsCache is registered as singleton. This causes whole test class to use one instance of the cache, which causes unwanted behavior.
    /// Each test method gets its own cache instance to prevent this.
    /// </summary>
    [TestClass]
    public class GameObjectsCacheTests : WhereContainerIsAvailable
    {
        private IGameObjectsCache _cache;

        [TestInitialize]
        public void OnTestInitialize()
        {
            var registration = Container.Registrations.Single(x => x.RegisteredType == typeof(IGameObjectsCache));
            _cache = Container.Resolve(registration.MappedToType) as IGameObjectsCache;
        }

        [TestMethod]
        public void UserExistsTest()
        {
            var hero = new ObjAiHeroBuilder().Build();
            _cache.Add(hero.NetId, hero);

            var exists = _cache.UserExists(hero.NetId);

            Assert.AreEqual(true, exists);
        }

        [TestMethod]
        public void GetObject_CorrectData_Test()
        {
            var hero = new ObjAiHeroBuilder().Build();
            _cache.Add(hero.NetId, hero);

            var obj = _cache.GetObject(hero.NetId);

            Assert.AreEqual(hero, obj);
        }

        [TestMethod]
        public void GetObject_WrongData_Test()
        {
            var hero = new ObjAiHeroBuilder().Build();
            _cache.Add(hero.NetId, hero);

            Assert.AreEqual(false, _cache.UserExists(hero.NetId + 1));
            var failed = false;
            try
            {
                var obj = _cache.GetObject(hero.NetId + 1);
            }
            catch (InvalidOperationException)
            {
                failed = true;
            }

            Assert.AreEqual(true, failed);
        }

        [TestMethod]
        public void FindByCriteria_CorrectData_Test()
        {
            var hero = new ObjAiHeroBuilder().Build();
            _cache.Add(hero.NetId, hero);
            _cache.Add(hero.NetId + 1, new ObjAiHeroBuilder().Build());

            var obj = _cache.FindByCriteria(x => x == hero);

            Assert.AreEqual(1, obj.Count());
            Assert.AreEqual(hero, obj.Single());
        }
    }
}
