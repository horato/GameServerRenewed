using System.Reflection;

namespace LeagueSandbox.GameServer.Utils
{
	public static class UtilsAssemblyDefiningType
	{
		public static Assembly Assembly => typeof(UtilsAssemblyDefiningType).Assembly;
	}
}
