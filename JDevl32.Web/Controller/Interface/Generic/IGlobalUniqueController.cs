// todo|jdevl: ???
/**
using JDevl32.Web.ViewModel;

namespace JDevl32.Web.Controller.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic, global) unique item controller.
	/// </summary>
	/// <typeparam name="TGlobalUniqueViewModel">
	/// A (global) unique item view model type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IGlobalUniqueController<in TGlobalUniqueViewModel>
		:
		IHttpController<TGlobalUniqueViewModel>
		where
			TGlobalUniqueViewModel
			:
			GlobalUniqueViewModelBase
	{

#region Property

		// todo|jdevl32: (if specified at all) needs to be refactored out into separate interface...
		/**
		/// <summary>
		/// A (global) unique item repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IGlobalUniqueRepository GlobalUniqueRepository { get; }
		/** /

#endregion

	}

}
/**/
