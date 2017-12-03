using Microsoft.Extensions.Logging;

namespace JDevl32.Logging.Interface
{

	/// <summary>
	/// A (generic) loggable object.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface ILoggable<TDerivedClass>
		where TDerivedClass : class
	{

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ILogger<TDerivedClass> Logger { get; }

	}

}
