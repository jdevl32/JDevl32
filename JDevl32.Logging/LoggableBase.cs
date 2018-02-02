using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// (Re-)implement (as non-generic loggable interface).
	/// </remarks>
	public abstract class LoggableBase
		:
		ILoggable
	{

#region Property

#region Implementation of ILoggable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public ILogger Logger { get; }

#endregion

#endregion

#region Instance Initialization

		// todo|jdevl32: is this needed anywhere ???
		/**
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// (Correctly) make abstract/protected.
		/// </remarks>
		protected LoggableBase(ILogger<LoggableBase> logger)
			:
			base(logger)
		{
		}
		/**/

#endregion

	}

}
