using JDevl32.Entity;
using JDevl32.Entity.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A(n) (generic) informable unique (integer) identifier entity item context repository.
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
	public interface IInformableUniqueIntEntityContextRepository<out TEntityContext, TUniqueEntity>
		:
		IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, int>
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
