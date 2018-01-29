using AutoMapper;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Web.Controller.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) global unique identifier entity item controller (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TRepository">
	/// This should be the type of the derived class of the repository (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InformableGuidUniqueEntityControllerBase<TDerivedClass, TRepository>
		:
		InformableUniqueEntityControllerBase<TDerivedClass, TRepository, Guid>
		where
			TDerivedClass
			:
			class
		where
			TRepository
			:
			class
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableGuidUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper, IInformableUniqueEntityContextRepository<TRepository, Guid> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, logger, mapper, informableUniqueEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
