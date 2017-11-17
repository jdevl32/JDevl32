﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller
{

	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class ControllerBase
		:
		ControllerBase<ControllerBase>
	{

#region Instance Initialization

		/// <inheritdoc />
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILogger<ControllerBase> logger)
			:
			base(hostingEnvironment, logger)
		{
		}

#endregion

	}

}
