using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) HTTP controller.
	/// </summary>
	/// <typeparam name="TViewModel">
	/// The view model type.
	/// </typeparam>
	/// <typeparam name="TViewModelBase">
	/// The view model (base class) type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IHttpController<in TViewModel, TViewModelBase>
		:
		IController
		where
			TViewModelBase
			:
			class
		where
			TViewModel
			:
			TViewModelBase
	{

#region Property

#endregion

		/// <summary>
		/// Delete (remove) (all) the item(s).
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
		/// Delete (remove) the item (specified by the view model).
		/// </summary>
		/// <param name="viewModel">
		/// The item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpDelete]
		Task<IActionResult> Delete([FromBody] TViewModel viewModel);

		/// <summary>
		/// Get (all) the item(s).
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
		/// Post (add or modify) the item (specified by the view model).
		/// </summary>
		/// <param name="viewModel">
		/// The item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpPost]
		Task<IActionResult> Post([FromBody] TViewModel viewModel);

	}

}
