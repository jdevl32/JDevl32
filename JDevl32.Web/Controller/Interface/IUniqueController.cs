using JDevl32.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller.Interface
{

	/// <inheritdoc />
	/// <summary>
	/// A unique item controller.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueController
		:
		IController
	{

#region Property

		/// <summary>
		/// The display name for the unique item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string DisplayName { get; }

		// todo|jdevl32: (if specified at all) needs to be refactored out into separate interface...
		/**
		/// <summary>
		/// A unique item repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueRepository UniqueRepository { get; }
		/**/

#endregion

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
		/// </remarks>
		[HttpDelete]
		Task<IActionResult> Delete([FromBody] UniqueViewModelBase uniqueViewModel);

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
		/// </remarks>
		[HttpPost]
		Task<IActionResult> Post([FromBody] UniqueViewModelBase uniqueViewModel);

	}

}
