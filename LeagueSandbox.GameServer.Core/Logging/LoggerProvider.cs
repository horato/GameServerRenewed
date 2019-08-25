using System.Diagnostics;
using log4net;

namespace LeagueSandbox.GameServer.Core.Logging
{
	public class LoggerProvider
	{
		public static ILog GetLogger()
		{
			var caller = new StackTrace().GetFrame(1).GetMethod().DeclaringType;
			return LogManager.GetLogger(caller);
		}
	}
}
