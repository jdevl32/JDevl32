using JDevl32.Entity.Model;
using JDevl32.Logging.Interface.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) unique item informable entity context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add unique item type.
	/// Refactor display-name (re-implement setter in base (informable) interface).
	/// </remarks>
	public interface IUniqueInformableEntityContextRepository<out TDerivedClass, TUnique>
		:
		IEntityContextRepository
		,
		IInformable<TDerivedClass>
		,
		IUniqueRepository<TUnique>
		where
			TDerivedClass
			:
			class
		where
			TUnique
			:
			UniqueBase
	{

#region Property

#endregion

	}

}
