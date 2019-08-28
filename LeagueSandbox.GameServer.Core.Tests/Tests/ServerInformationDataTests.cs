using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueSandbox.GameServer.Lib.Tests.Tests
{
    [TestClass]
    public class ServerInformationDataTests
    {
        [TestMethod]
        public void TestInformationData()
        {
            var startTime = DateTime.Now;
            var version = "TEST_VERSION";

            var instance = new ServerInformationData(startTime, version);

            Assert.AreEqual(startTime, instance.StartTime);
            Assert.AreEqual(version, instance.Version);
        }
    }
}
