using System;
using System.Collections.Generic;

namespace LeagueSandbox.GameServer.Networking.Communication
{
	internal interface IServerActionProvider
	{
		IDictionary<Type, Type> ProvideServerActions();
    }
}