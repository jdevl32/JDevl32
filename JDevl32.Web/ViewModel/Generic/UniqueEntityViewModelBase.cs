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
	/// </remarks>
	public abstract class UniqueEntityViewModelBase<T>
		:
		UniqueEntityBase<T>
		where
			T
			:
			struct
	{

#region Property

		/// <summary>
		/// The unique identifier for the unique entity item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected new T Id { get; set; }

#endregion

	}

}
