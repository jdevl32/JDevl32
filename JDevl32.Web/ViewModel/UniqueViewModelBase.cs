using JDevl32.Entity.Model;

namespace JDevl32.Web.ViewModel
{

	/// <inheritdoc />
	/// <summary>
	/// A unique item view model (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Remove (generic) unique item type.
	/// Re-implement id as protected (from view model).
	/// </remarks>
	public abstract class UniqueViewModelBase
		:
		UniqueBase
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected new int Id { get; set; }

#endregion

	}

}
