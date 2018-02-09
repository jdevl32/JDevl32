using JDevl32.Web.ViewModel.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller.Interface.Generic
{
	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique entity item controller.
	/// </summary>
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item view model.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the (contravariant) type of the unique entity item view model.
	/// </remarks>
	public interface IUniqueEntityController<in TUniqueEntityViewModel, TUniqueValue>
		:
		IController
		where
			TUniqueEntityViewModel
			:
			UniqueEntityViewModelBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{

#region Property

		// todo|jdevl32: (if specified at all) needs to be refactored out into separate interface...
		/**
		/// <summary>
		/// A unique entity item repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueRepository UniqueRepository { get; }
		/**/

#endregion

		/// <summary>
		/// Delete (remove) (all) the unique entity item(s).
		/// </summary>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Remove name specification from http-delete attribute.
		/// </remarks>
		[HttpDelete("*")]
		Task<IActionResult> Delete();

		/// <summary>
		/// Delete (remove) the unique entity item (specified by the view model).
		/// </summary>
		/// <param name="uniqueEntityViewModel">
		/// The unique entity item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item view model.
		/// </remarks>
		[HttpDelete]
		Task<IActionResult> Delete([FromBody] TUniqueEntityViewModel uniqueEntityViewModel);

		/// <summary>
		/// Get (all) the unique entity item(s).
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
		/// Post (add or modify) the unique entity item (specified by the view model).
		/// </summary>
		/// <param name="uniqueEntityViewModel">
		/// The unique entity item view model.
		/// </param>
		/// <returns>
		/// An (async) action result task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item view model.
		/// </remarks>
		[HttpPost]
		Task<IActionResult> Post([FromBody] TUniqueEntityViewModel uniqueEntityViewModel);

	}

}
