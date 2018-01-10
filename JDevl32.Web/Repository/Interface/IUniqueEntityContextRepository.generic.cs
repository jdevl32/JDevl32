using JDevl32.Entity.Interface;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item entity context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueEntityContextRepository<TDerivedClass, TUnique>
		:
		IEntityContextRepository<TDerivedClass>
		,
		IUniqueRepository<TUnique>
		where
			TDerivedClass
			:
			class
		where
			TUnique
			:
			IUnique
	{

#region Property

#endregion

	}

}
