using JDevl32.Logging.Interface;
using JDevl32.Web.Controller.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller
{

	/// <summary>
	/// A generic (web) controller (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Implement loggable interface.
	/// </remarks>
	public abstract class ControllerBase<TDerivedClass>
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		ILoggable<TDerivedClass>
		,
		IController
		where TDerivedClass : class
	{

#region Property

#region IController

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region ILoggable<TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Make public (for loggable interface implementation) and virtual.
		/// </remarks>
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#endregion

#region Instance Initialization

		// todo|jdevl32: not needed ???
		/**
		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected ControllerBase(ILogger<TDerivedClass> logger) => Logger = logger;
		**/

		/// <inheritdoc />
		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="hostingEnvironment">
		/// The hosting environment.
		/// </param>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger)
			// todo|jdevl32: (see above) ???
			//:
			//this(logger) => HostingEnvironment = hostingEnvironment;

		{
			HostingEnvironment = hostingEnvironment;
			Logger = logger;
		}

#endregion

	}

}
