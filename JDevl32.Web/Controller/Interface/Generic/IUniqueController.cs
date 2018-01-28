// todo|jdevl32: ???
/**
using JDevl32.Web.ViewModel;

namespace JDevl32.Web.Controller.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique item controller.
	/// </summary>
	/// <typeparam name="TUniqueViewModel">
	/// A unique item view model type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement as (generic) HTTP controller.
	/// </remarks>
	public interface IUniqueController<in TUniqueViewModel>
		:
		IHttpController<TUniqueViewModel>
		where
			TUniqueViewModel
			:
			UniqueViewModelBase
	{

#region Property

		// todo|jdevl32: (if specified at all) needs to be refactored out into separate interface...
		/**
		/// <summary>
		/// A unique item repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueRepository UniqueRepository { get; }
		/** /

#endregion

		// todo|jdevl32: cleanup...
		/**
		/// <summary>
		/// Delete (remove) (all) the unique item(s).
		/// </summary>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpDelete("*", Name = "RemoveAll")]
		Task<IActionResult> Delete();

		/// <summary>
		/// Delete (remove) the unique item (specified by the view model).
		/// </summary>
		/// <param name="uniqueViewModel">
		/// The unique item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add unique item view model type.
		/// </remarks>
		[HttpDelete]
		Task<IActionResult> Delete([FromBody] TUniqueViewModel uniqueViewModel);

		/// <summary>
		/// Get (all) the unique item(s).
		/// </summary>
		/// <returns>
		/// An action result.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpGet]
		IActionResult Get();

		/// <summary>
		/// Post (add or modify) the unique item (specified by the view model).
		/// </summary>
		/// <param name="uniqueViewModel">
		/// The unique item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add unique item view model type.
		/// </remarks>
		[HttpPost]
		Task<IActionResult> Post([FromBody] TUniqueViewModel uniqueViewModel);
		/** /

	}

}
/**/
