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
	/// A (generic) unique identifier entity item controller (base class).
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
	public abstract class InformableIntUniqueEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel>
		:
		InformableUniqueEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel, int>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<int>
		where
			TUniqueEntityViewModel
			:
			UniqueEntityViewModelBase<int>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableIntUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, int> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, loggerFactory, mapper, informableUniqueEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
