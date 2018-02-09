using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using JDevl32.Web.ViewModel.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller.Generic
{
	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique (integer) identifier entity item controller (base class).
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
	/// Add the type of the unique entity item view model.
	/// </remarks>
	public abstract class InformableUniqueIntEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel>
		:
		InformableUniqueEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel, int>
		// todo|jdevl32: implement (new int) type-specific interface ???
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			// todo|jdevl32: replace with (int) type-specific ???
			UniqueEntityBase<int>
		where
			TUniqueEntityViewModel
			:
			// todo|jdevl32: replace with (int) type-specific ???
			UniqueEntityViewModelBase<int>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor (rename) (repository) parameter per type.
		/// </remarks>
		protected InformableUniqueIntEntityControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, IInformableUniqueIntEntityContextRepository<TEntityContext, TUniqueEntity> informableUniqueIntEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, loggerFactory, mapper, informableUniqueIntEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
