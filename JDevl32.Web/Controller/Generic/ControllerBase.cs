using AutoMapper;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Mapper.Interface;
using JDevl32.Web.Controller.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller.Generic
{

	/// <summary>
	/// A (generic, web) controller (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Implement instance mapper interface.
	/// </remarks>
	public abstract class ControllerBase<TDerivedClass>
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		ILoggable<TDerivedClass>
		,
		IController
		,
		IInstanceMapper
		where
			TDerivedClass
			:
			class
	{

#region Property

#region Implementation of IController

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Implementation of ILoggable<TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Make public (for loggable interface implementation) and virtual.
		/// </remarks>
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#region Implementation of IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IMapper Mapper { get; }

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
		/// The (injected) hosting environment.
		/// </param>
		/// <param name="logger">
		/// The (injected) logger.
		/// </param>
		/// <param name="mapper">
		/// The (injected) mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Implement instance mapper interface.
		/// </remarks>
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper)
			// todo|jdevl32: (see above) ???
			//:
			//this(logger) => HostingEnvironment = hostingEnvironment;
		{
			HostingEnvironment = hostingEnvironment;
			Logger = logger;
			Mapper = mapper;
		}

#endregion

	}

}
