using JDevl32.Logging.Generic;
using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// (Correctly) make abstract.
	/// </remarks>
	public abstract class LoggableBase
		:
		LoggableBase<LoggableBase>
	{

#region Instance Initialization

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

#endregion

	}

}
