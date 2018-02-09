using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace JDevl32.Entity.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A(n) (generic) informable unique (integer) identifier entity context sower (base class).
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
	public abstract class InformableUniqueIntEntityContextSowerBase<TEntityContext, TUniqueEntity>
		:
		InformableEntityContextSowerBase<TEntityContext, TUniqueEntity, int>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<int>
	{

#region Property

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueIntEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
			:
			base(entityContext, loggerFactory)
		{
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueIntEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, string displayName)
			:
			base(entityContext, loggerFactory, displayName)
		{
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueIntEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, IEnumerable<TUniqueEntity> entity)
			:
			base(entityContext, loggerFactory, entity)
		{
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueIntEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, string displayName, IEnumerable<TUniqueEntity> entity)
			:
			base(entityContext, loggerFactory, displayName, entity)
		{
		}

#endregion

	}

}
