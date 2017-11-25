﻿using JDevl32.Web.Controller.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller
{

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class ControllerBase<TDerivedClass>
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IBaseController
		where TDerivedClass : class
	{

#region Property

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ILogger<TDerivedClass> Logger { get; }

#endregion

#region Instance Initialization

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
			:
			this(logger) => HostingEnvironment = hostingEnvironment;

#endregion

	}

}
