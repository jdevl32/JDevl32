using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
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
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InformableGuidUniqueEntityControllerBase<TEntityContext, TUniqueEntity>
		:
		InformableUniqueEntityControllerBase<TEntityContext, TUniqueEntity, Guid>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<Guid>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableGuidUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, Guid> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, loggerFactory, mapper, informableUniqueEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
