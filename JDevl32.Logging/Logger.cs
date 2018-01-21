using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <summary>
	/// A globally available logger.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class Logger
	{

#region Property

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static ILogger Instance { get; }

		// todo|jdevl32: ???
		///// <summary>
		///// The logger factory.
		///// </summary>
		///// <remarks>
		///// Last modification:
		///// </remarks>
		//public static ILoggerFactory LoggerFactory { get; }

		//private static IServiceProvider ServiceProvider { get; }

#endregion

#region Type Initialization

		/// <summary>
		/// Create a logger (type).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		static Logger()
		{
			Instance =
				new ServiceCollection()
					.AddLogging()
					.BuildServiceProvider()
					.GetService<ILoggerFactory>()
					.AddConsole()
					.AddDebug()
					.CreateLogger(typeof(Logger).ToString())
			;
		}

#endregion

	}

}
