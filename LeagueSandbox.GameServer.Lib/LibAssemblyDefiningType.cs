using System.Reflection;

namespace LeagueSandbox.GameServer.Lib
{
	public static class LibAssemblyDefiningType
	{
		public static Assembly Assembly => typeof(LibAssemblyDefiningType).Assembly;
	}
}
