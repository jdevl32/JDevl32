using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Web.Controller.Interface.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using JDevl32.Web.ViewModel.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Web.Controller.Generic
{

	/// <summary>
	/// A (generic) global unique (GUID) identifier entity item controller (base class).
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Enhance type-specific interface(s) (and implementation(s)).
	/// </remarks>
	public abstract class InformableUniqueGuidEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel>
		:
		InformableUniqueEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel, Guid>
		,
		IInformableUniqueGuidEntityController<TUniqueEntityViewModel>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			// todo|jdevl32: replace with (guid) type-specific ???
			UniqueEntityBase<Guid>
		where
			TUniqueEntityViewModel
			:
			// todo|jdevl32: replace with (guid) type-specific ???
			UniqueEntityViewModelBase<Guid>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor (rename) (repository) parameter per type.
		/// </remarks>
		protected InformableUniqueGuidEntityControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, IInformableUniqueGuidEntityContextRepository<TEntityContext, TUniqueEntity> informableUniqueGuidEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, loggerFactory, mapper, informableUniqueGuidEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
