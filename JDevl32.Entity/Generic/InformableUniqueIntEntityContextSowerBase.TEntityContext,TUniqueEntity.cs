using JDevl32.Entity.Interface.Generic;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace JDevl32.Entity.Generic
{

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
	/// Enhance type-specific interface(s) (and implementation(s)).
	/// </remarks>
	public abstract class InformableUniqueIntEntityContextSowerBase<TEntityContext, TUniqueEntity>
		:
		InformableEntityContextSowerBase<TEntityContext, TUniqueEntity, int>
		,
		//IInformableIntEntityContextSower<TEntityContext, TUniqueEntity>
		IIntEntityContextSower<TEntityContext, TUniqueEntity>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			// todo|jdevl32: replace with (int) type-specific ???
			UniqueEntityBase<int>
	{

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
