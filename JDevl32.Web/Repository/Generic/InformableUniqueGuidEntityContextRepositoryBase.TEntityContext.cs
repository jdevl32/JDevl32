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
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InformableUniqueGuidEntityContextRepositoryBase<TEntityContext, TUniqueEntity>
		:
		InformableUniqueEntityContextRepositoryBase<TEntityContext, TUniqueEntity, Guid>
		,
		IInformableUniqueGuidEntityContextRepository<TEntityContext, TUniqueEntity>
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
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <param name="uniqueEntityDbSet">
		/// A db-set of (all) the global unique (GUID) identifier entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueGuidEntityContextRepositoryBase(TEntityContext entityContext, ILoggerFactory loggerFactory, DbSet<TUniqueEntity> uniqueEntityDbSet)
			:
			base(entityContext, loggerFactory, uniqueEntityDbSet)
		{
		}

#endregion

	}

}
