using JDevl32.Entity.Generic;
using System;

namespace JDevl32.Entity.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A sower (seeder) for a(n) (GUID) indentifier entity context.
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
	public interface IGuidEntityContextSower<out TEntityContext, TUniqueEntity>
		:
		IEntityContextSower<TEntityContext, TUniqueEntity, Guid>
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
	}

}
