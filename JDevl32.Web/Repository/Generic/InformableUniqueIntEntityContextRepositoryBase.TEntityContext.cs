using JDevl32.Entity;
using JDevl32.Entity.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Repository.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique (integer) identifier entity item context repository (base class).
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
	public abstract class InformableUniqueIntEntityContextRepositoryBase<TEntityContext, TUniqueEntity>
		:
		InformableUniqueEntityContextRepositoryBase<TEntityContext, TUniqueEntity, int>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<int>
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
		/// A db-set of (all) the unique (integer) identifier entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueIntEntityContextRepositoryBase(TEntityContext entityContext, ILoggerFactory loggerFactory, DbSet<TUniqueEntity> uniqueEntityDbSet)
			:
			base(entityContext, loggerFactory, uniqueEntityDbSet)
		{
		}

#endregion

	}

}
