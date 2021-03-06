﻿using AutoMapper;
using JDevl32.Logging.Interface;
using JDevl32.Mapper.Interface;
using JDevl32.Web.Controller.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller
{

	/// <summary>
	/// A (web) controller (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Refactor loggable logger category name.
	/// </remarks>
	public abstract class ControllerBase
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		ILoggable
		,
		IController
		// todo|jdevl32: ???
		/**/
		,
		IInstanceMapper
		/**/
	{

#region Property

#region Implementation of IController

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Implementation of ILoggable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Make public (for loggable interface implementation) and virtual.
		/// </remarks>
		public virtual ILogger Logger { get; }

#endregion

		// todo|jdevl32: ???
		/**/
#region Implementation of IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IMapper Mapper { get; }

#endregion
		/**/

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="hostingEnvironment">
		/// The (injected) hosting environment.
		/// </param>
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <param name="mapper">
		/// A(n auto-)mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Refactor loggable logger category name.
		/// </remarks>
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper)
		{
			HostingEnvironment = hostingEnvironment;
			Logger = loggerFactory.CreateLogger(GetType());
			// todo|jdevl32: ???
			Mapper = mapper;
		}

#endregion

	}

}
