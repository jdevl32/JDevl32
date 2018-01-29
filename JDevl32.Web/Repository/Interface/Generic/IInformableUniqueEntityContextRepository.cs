using JDevl32.Logging.Interface.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) informable unique entity item context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueEntityContextRepository<out TDerivedClass, TUniqueValue>
		:
		IEntityContextRepository
		,
		IInformable<TDerivedClass>
		,
		IUniqueEntityRepository<TUniqueValue>
		where
			TDerivedClass
			:
			class
		where
			TUniqueValue
			:
			struct
	{
	}

}
