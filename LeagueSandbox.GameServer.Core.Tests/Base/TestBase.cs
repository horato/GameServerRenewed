using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Packets420;

namespace LeagueSandbox.GameServer.Lib.Tests.Base
{
	public class TestBase
	{
		protected IEnumerable<Assembly> GetAllApplicationAssemblies()
		{
			yield return NetworkingAssemblyDefiningType.Assembly;
			yield return NetworkingCoreAssemblyDefiningType.Assembly;
			yield return PacketsAssemblyDefiningType.Assembly;
			yield return CoreAssemblyDefiningType.Assembly;
			yield return LibAssemblyDefiningType.Assembly;
		}
	}
}
