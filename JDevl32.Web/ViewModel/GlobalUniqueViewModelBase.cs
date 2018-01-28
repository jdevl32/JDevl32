using JDevl32.Entity.Model;
using System;

namespace JDevl32.Web.ViewModel
{

	/// <inheritdoc />
	/// <summary>
	/// A (global) unique item view model (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class GlobalUniqueViewModelBase
		:
		GlobalUniqueBase
	{

#region Property

		/// <summary>
		/// The (globally) unique identifier.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected new Guid Id { get; set; }

#endregion

	}

}
