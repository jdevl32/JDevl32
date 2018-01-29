using AutoMapper;
using JDevl32.Entity.Generic;
using JDevl32.Entity.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Web.Repository.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) global unique identifier entity item context repository (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TEntityContext">
	/// The entity context type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InformableGuidUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext>
		:
		InformableUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, Guid>
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
		/// A db-set of (all) the global unique identifier entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableGuidUniqueEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<UniqueEntityBase<Guid>> uniqueEntityDbSet)
			:
			base(entityContext, logger, mapper, uniqueEntityDbSet)
		{
		}

#endregion

	}

}
