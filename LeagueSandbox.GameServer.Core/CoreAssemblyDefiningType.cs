using System.Reflection;

namespace LeagueSandbox.GameServer.Core
{
	public static class CoreAssemblyDefiningType
	{
		public static Assembly Assembly => typeof(CoreAssemblyDefiningType).Assembly;
	}
}
