using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Logging.Interface;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A(n) (generic) informable unique entity item context repository.
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueEntityContextRepository<out TEntityContext, TUniqueEntity, TUniqueValue>
		:
		IEntityContextRepository<TEntityContext>
		,
		IInformable
		,
		IUniqueEntityRepository<TUniqueEntity, TUniqueValue>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{
	}

}
