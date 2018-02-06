using JDevl32.Entity.Generic;

namespace JDevl32.Web.ViewModel.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A unique entity item view model (base class).
	/// </summary>
	/// <typeparam name="T">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Remove (protected) restriction on view model id.
	/// </remarks>
	public abstract class UniqueEntityViewModelBase<T>
		:
		UniqueEntityBase<T>
		where
			T
			:
			struct
	{
	}

}
