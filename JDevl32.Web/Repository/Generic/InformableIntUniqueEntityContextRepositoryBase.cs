using AutoMapper;
using JDevl32.Entity.Generic;
using JDevl32.Entity.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Repository.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique identifier entity item context repository (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TEntityContext">
	/// The entity context type.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item.
	/// </remarks>
	public abstract class InformableIntUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUniqueEntity>
		:
		InformableUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUniqueEntity, int>
		where
			TDerivedClass
			:
			class
		where
			TEntityContext
			:
			DbContext
			,
			IEntityContext
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
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <param name="mapper">
		/// A mapper.
		/// </param>
		/// <param name="uniqueEntityDbSet">
		/// A db-set of (all) the unique identifier entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected InformableIntUniqueEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<TUniqueEntity> uniqueEntityDbSet)
			:
			base(entityContext, logger, mapper, uniqueEntityDbSet)
		{
		}

#endregion

	}

}
