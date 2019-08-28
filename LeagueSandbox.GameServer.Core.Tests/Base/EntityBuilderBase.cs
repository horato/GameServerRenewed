using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Lib.Tests.Base
{
    public abstract class EntityBuilderBase<TEntity>
    {
        public abstract TEntity Build();
    }
}
