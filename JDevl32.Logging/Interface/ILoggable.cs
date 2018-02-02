using Microsoft.Extensions.Logging;

namespace JDevl32.Logging.Interface
{

	/// <summary>
	/// A loggable object.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement (no interface extension).
	/// </remarks>
	public interface ILoggable
	{

#region Property

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ILogger Logger { get; }

#endregion

	}

}
