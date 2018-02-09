using JDevl32.Entity.Generic;

namespace JDevl32.Entity.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A sower (seeder) for a(n) (integer) indentifier entity context.
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
	public interface IIntEntityContextSower<out TEntityContext, TUniqueEntity>
		:
		IEntityContextSower<TEntityContext, TUniqueEntity, int>
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
	}

}
