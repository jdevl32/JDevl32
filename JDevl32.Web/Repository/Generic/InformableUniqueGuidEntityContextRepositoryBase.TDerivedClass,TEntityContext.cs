using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Web.Repository.Generic
{

	/// <summary>
	/// A (generic) global unique (GUID) identifier entity item context repository (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Enhance type-specific interface(s) (and implementation(s)).
	/// </remarks>
	public abstract class InformableUniqueGuidEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUniqueEntity>
		:
		InformableUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUniqueEntity, Guid>
		,
		IInformableUniqueGuidEntityContextRepository<TEntityContext, TUniqueEntity>
		where
			TDerivedClass
			:
			class
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			// todo|jdevl32: replace with (guid) type-specific ???
			UniqueEntityBase<Guid>
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <param name="entityContext">
		/// An entity context.
		/// </param>
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <param name="mapper">
		/// A mapper.
		/// </param>
		/// <param name="uniqueEntityDbSet">
		/// A db-set of (all) the global unique (GUID) identifier entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
	/// Add the type of the unique entity item.
		/// </remarks>
		protected InformableUniqueGuidEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<TUniqueEntity> uniqueEntityDbSet)
			:
			base(entityContext, logger, mapper, uniqueEntityDbSet)
		{
		}

#endregion

	}

}
