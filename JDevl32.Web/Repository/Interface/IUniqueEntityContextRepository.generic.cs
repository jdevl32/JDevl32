using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item entity context repository.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The unique item entity type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Remove derived class type.
	/// (Re-)inherit non-generic entity context repository.
	/// Add unique item entity type.
	/// </remarks>
	public interface IUniqueEntityContextRepository<TUnique, TUniqueEntity>
		:
		IEntityContextRepository
		,
		IUniqueRepository<TUnique, TUniqueEntity>
		where
			TUnique
			:
			IUnique
		where
			TUniqueEntity
			:
			UniqueBase
	{

#region Property

#endregion

	}

}
