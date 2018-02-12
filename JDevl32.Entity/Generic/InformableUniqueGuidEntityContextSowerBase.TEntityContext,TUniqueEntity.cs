using JDevl32.Entity.Interface.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A(n) (generic) informable unique (GUID) identifier entity context sower (base class).
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Remove unnecessary constructor.
	/// </remarks>
	public abstract class InformableUniqueGuidEntityContextSowerBase<TEntityContext, TUniqueEntity>
		:
		InformableEntityContextSowerBase<TEntityContext, TUniqueEntity, Guid>
		,
		//IInformableGuidEntityContextSower<TEntityContext, TUniqueEntity>
		IGuidEntityContextSower<TEntityContext, TUniqueEntity>
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
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueGuidEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
			:
			base(entityContext, loggerFactory)
		{
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueGuidEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, string displayName)
			:
			base(entityContext, loggerFactory, displayName)
		{
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueGuidEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, string displayName, IEnumerable<TUniqueEntity> entity)
			:
			base(entityContext, loggerFactory, displayName, entity)
		{
		}

#endregion

	}

}
