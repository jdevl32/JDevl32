using JDevl32.Entity.Model;
using JDevl32.Logging.Interface.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic, global) unique item informable entity context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TGlobalUnique">
	/// The (global) unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IGlobalUniqueInformableEntityContextRepository<out TDerivedClass, TGlobalUnique>
		:
		IEntityContextRepository
		,
		IInformable<TDerivedClass>
		,
		IGlobalUniqueRepository<TGlobalUnique>
		where
			TDerivedClass
			:
			class
		where
			TGlobalUnique
			:
			GlobalUniqueBase
	{

#region Property

#endregion

	}

}
