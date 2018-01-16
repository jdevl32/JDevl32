using AutoMapper;
using JDevl32.Web.Controller.Interface;
using JDevl32.Web.Repository.Interface;
using JDevl32.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller
{

	/// <summary>
	/// A unique item controller.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Remove unique item (and entity) type(s).
	/// </remarks>
	public abstract class UniqueEntityContextControllerBase<TDerivedClass>
		:
		ControllerBase<TDerivedClass>
		,
		IUniqueController
		where
			TDerivedClass
			:
			class
	{

#region Property

#region IUniqueController

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string DisplayName { get; }

#endregion

		/// <summary>
		/// A unique item entity context repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Remove derived class type.
		/// Add unique item entity type.
		/// </remarks>
		public virtual IUniqueEntityContextRepository UniqueEntityContextRepository { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Remove unique item (and entity) type(s) from unique entity context repository.
		/// </remarks>
		protected UniqueEntityContextControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper,  IUniqueEntityContextRepository uniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, logger, mapper)
		{
			DisplayName = displayName;
			UniqueEntityContextRepository = uniqueEntityContextRepository;

			// todo|jdevl32: ??? consider display name property instead ???
			// Set the controller of the repository (for display name).
			UniqueEntityContextRepository.UniqueController = this;
		}

#endregion

#region IUniqueController<TUnique>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Enhance exception handling.
		/// </remarks>
		[HttpDelete("*", Name = "RemoveAll")]
		public virtual async Task<IActionResult> Delete()
		{
			// todo|jdevl32: contant(s)...
			var task =
				new Task<IActionResult>
				(
					() =>
					{
						if (ModelState.IsValid)
						{
							UniqueEntityContextRepository.Remove();

							var saveChangesAsync = UniqueEntityContextRepository.SaveChangesAsync();
							saveChangesAsync.Wait();

							if (saveChangesAsync.Result)
							{
								return Ok();
							} // if
						} // if
						else if (HostingEnvironment.IsDevelopment())
						{
							return BadRequest(ModelState);
						} // if

						return BadRequest();
					}
				)
			;

			return await Do(GetInfo(nameof(Delete), "from"), "removing", task);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Enhance exception handling.
		/// </remarks>
		[HttpDelete]
		public virtual async Task<IActionResult> Delete(UniqueViewModelBase uniqueViewModel)
		{
			// todo|jdevl32: contant(s)...
			var task =
				new Task<IActionResult>
					(
						() =>
						{
							if (ModelState.IsValid)
							{
								// todo|jdevl32: ???
								//uniqueViewModel.UserName = User.Identity.Name;

								UniqueEntityContextRepository.Remove(uniqueViewModel);

								var saveChangesAsync = UniqueEntityContextRepository.SaveChangesAsync();
								saveChangesAsync.Wait();

								if (saveChangesAsync.Result)
								{
									return Ok();
								} // if
							} // if
							else if (HostingEnvironment.IsDevelopment())
							{
								return BadRequest(ModelState);
							} // if

							return BadRequest();
						}
					)
			;

			return await Do(GetInfo(nameof(Delete), "from", uniqueViewModel), "removing", task);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add (missing) HTTP method attribute specification(s).
		/// </remarks>
		[HttpGet]
		public virtual IActionResult Get()
		{
			// todo|jdevl32: contant(s)...
			var func = new Func<IActionResult>(() => Ok(Mapper.Map<IEnumerable<UniqueViewModelBase>>(UniqueEntityContextRepository.Get())));

			return Do(GetInfo(nameof(Get), "from"), "retrieving", func);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Enhance exception handling.
		/// </remarks>
		[HttpPost]
		public virtual async Task<IActionResult> Post(UniqueViewModelBase uniqueViewModel)
		{
			// todo|jdevl32: contant(s)...
			var task =
				new Task<IActionResult>
					(
						() =>
						{
							if (ModelState.IsValid)
							{
								//uniqueViewModel.UserName = User.Identity.Name;

								UniqueEntityContextRepository.Update(uniqueViewModel);

								var saveChangesAsync = UniqueEntityContextRepository.SaveChangesAsync();
								saveChangesAsync.Wait();

								if (saveChangesAsync.Result)
								{
									// todo|jdevl32: !!! revisit this !!!
									/**
									// Use map in case database modified the unique item in any way.
									var value = Mapper.Map<IUniqueViewModel<TUnique>>(uniqueViewModel);
	
									return Accepted($"{Request.Path.Value}/{value.Id}", value);
									/**/
									// todo|jdevl32: ??? does this work for add/new ???
									return Accepted($"{Request.Path.Value}/{uniqueViewModel.Id}", uniqueViewModel);
								} // if
							} // if
							else if (HostingEnvironment.IsDevelopment())
							{
								return BadRequest(ModelState);
							} // if

							return BadRequest();
						}
					)
			;

			return await Do(GetInfo(nameof(Post), "to", uniqueViewModel), "posting", task);
		}

#endregion

		/// <summary>
		/// Invoke a method, logging possible error information, and return the value (of the method invocation).
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A method to invoke.
		/// </param>
		/// <returns>
		/// The value (of the method invocation).
		/// </returns>
		protected virtual IActionResult Do(string info, string action, Func<IActionResult> method)
		{
			try
			{
				return method();
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
			} // catch

			return BadRequest();
		}

		/// <summary>
		/// Await a task, logging possible error information, and return the result (of the task).
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="task">
		/// A task to await.
		/// </param>
		/// <returns>
		/// The result (of the task).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual async Task<IActionResult> Do(string info, string action, Task<IActionResult> task)
		{
			try
			{
				return await task;
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
			} // catch

			return BadRequest();
		}

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual string GetInfo(string action, string direction) => GetInfo(action, () => GetInfo(direction));

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="item">
		/// An item to include in the (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual string GetInfo(string action, string direction, object item) => GetInfo(action, () => GetInfo(direction, item));

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A method to get (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual string GetInfo(string action, Func<string> method)
		{
			Logger.LogInformation(action);

			var info = string.Empty;

			try
			{
				info = method();

				Logger.LogInformation($"...{info}...");
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, string.Empty);
			} // catch

			return info;
		}

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual string GetInfo(string direction) => $" (all) the {DisplayName}(s) {direction} the repository";

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="item">
		/// An item to include in the (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual string GetInfo(string direction, object item) => $" the {DisplayName} ({item}) {direction} the repository";

	}

}
