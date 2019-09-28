using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueSandbox.GameServer.Lib.Tests.Support
{
    [TestClass]
    public class BuilderGeneratorTest
    {
        [TestMethod]
        public void Generate()
        {
            var sb = new StringBuilder();
            var types = new Type[]
            {
                //typeof(SpellBook),
                //typeof(Spell),
                //typeof(SpellInstance),
            };

            foreach (var type in types)
            {
                sb.AppendLine(new BuilderGeneratorService().GenerateBuilderTemplate(type));
            }

            if(types.Any())
                Assert.Fail(sb.ToString());
        }
    }
}
