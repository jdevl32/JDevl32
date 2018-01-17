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

		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Hide/redefine base (to add setter).
		/// </remarks>
		new string DisplayName { get; set; }

#endregion

	}

}
