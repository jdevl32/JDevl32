using AutoMapper;
using JDevl32.Entity.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Controller.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique identifier entity item controller (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TRepository">
	/// This should be the type of the derived class of the repository (for the logger).
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item.
	/// </remarks>
	public abstract class InformableIntUniqueEntityControllerBase<TDerivedClass, TRepository, TUniqueEntity>
		:
		InformableUniqueEntityControllerBase<TDerivedClass, TRepository, TUniqueEntity, int>
		where
			TDerivedClass
			:
			class
		where
			TRepository
			:
			class
		where
			TUniqueEntity
			:
			UniqueEntityBase<int>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected InformableIntUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper, IInformableUniqueEntityContextRepository<TRepository, TUniqueEntity, int> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, logger, mapper, informableUniqueEntityContextRepository, displayName)
		{
		}

#endregion

	}

}
