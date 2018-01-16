using JDevl32.Logging.Interface.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) unique item informable entity context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueInformableEntityContextRepository<out TDerivedClass>
		:
		IEntityContextRepository
		,
		IInformable<TDerivedClass>
		,
		IUniqueRepository
		where
			TDerivedClass
			:
			class
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
