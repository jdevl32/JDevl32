using JDevl32.Entity.Generic;
using JDevl32.Logging.Interface.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) informable unique entity item context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item.
	/// </remarks>
	public interface IInformableUniqueEntityContextRepository<out TDerivedClass, TUniqueEntity, TUniqueValue>
		:
		IEntityContextRepository
		,
		IInformable<TDerivedClass>
		,
		IUniqueEntityRepository<TUniqueEntity, TUniqueValue>
		where
			TDerivedClass
			:
			class
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
