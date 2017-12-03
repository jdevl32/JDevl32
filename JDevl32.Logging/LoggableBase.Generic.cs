using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <inheritdoc />
	public abstract class LoggableBase<TDerivedClass>
		:
		ILoggable<TDerivedClass>
		where TDerivedClass : class
	{

#region Property

#region ILoggable<TDerivedClass>

		/// <inheritdoc />
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a loggable object.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected LoggableBase(ILogger<TDerivedClass> logger) => Logger = logger;

#endregion

	}

}
