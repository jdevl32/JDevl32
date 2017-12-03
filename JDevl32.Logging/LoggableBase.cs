using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <inheritdoc />
	public class LoggableBase
		:
		LoggableBase<LoggableBase>
	{

#region Instance Initialization

		/// <inheritdoc />
		public LoggableBase(ILogger<LoggableBase> logger)
			:
			base(logger)
		{
		}

#endregion

	}

}
