﻿using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;

namespace JDevl32.Logging
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// Implement constructor (with injected logger).
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

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Enhance logger creation (from logger factory).
		/// </remarks>
		protected LoggableBase(ILoggerFactory loggerFactory)
			=>
			Logger = loggerFactory.CreateLogger(GetType());

#endregion

	}

}
