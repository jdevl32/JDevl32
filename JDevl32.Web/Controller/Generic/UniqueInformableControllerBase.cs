using AutoMapper;
using JDevl32.Logging.Extension;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Web.Controller.Interface;
using JDevl32.Web.Repository.Interface.Generic;
using JDevl32.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller.Generic
{

	/// <summary>
	/// A unique item controller.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Refactor display name to informable (interface).
	/// Implement informable (interface).
	/// </remarks>
	public abstract class UniqueInformableControllerBase<TDerivedClass>
		:
		ControllerBase<TDerivedClass>
		,
		IInformable<TDerivedClass>
		,
		IUniqueController
		where
			TDerivedClass
			:
			class
	{

#region Property

#region IInformable<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string DisplayName { get; }

#endregion

		/// <summary>
		/// A unique item informable entity context repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add derived class type.
		/// Refactor (rename).
		/// </remarks>
		public virtual IUniqueInformableEntityContextRepository<TDerivedClass> UniqueInformableEntityContextRepository { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Remove unique item controller from unique entity context repository.
		/// Add derived class type (to unique entity context repository).
		/// Refactor display name to informable (interface).
		/// Refactor (rename) repository.
		/// </remarks>
		protected UniqueInformableControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper, IUniqueInformableEntityContextRepository<TDerivedClass> uniqueInformableEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, logger, mapper)
		{
			UniqueInformableEntityContextRepository = uniqueInformableEntityContextRepository;

			// Set the display name (and the same for the repository).
			UniqueInformableEntityContextRepository.DisplayName = DisplayName = displayName;
		}

#endregion

#region IUniqueController

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
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
							UniqueInformableEntityContextRepository.Remove();

							var saveChangesAsync = UniqueInformableEntityContextRepository.SaveChangesAsync();
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

			return await Do(this.GetInfo(nameof(Delete), "from", "repository"), "removing", task);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
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

								UniqueInformableEntityContextRepository.Remove(uniqueViewModel);

								var saveChangesAsync = UniqueInformableEntityContextRepository.SaveChangesAsync();
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

			return await Do(this.GetInfo(nameof(Delete), "from", "repository", uniqueViewModel), "removing", task);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
		/// </remarks>
		[HttpGet]
		public virtual IActionResult Get()
		{
			// todo|jdevl32: contant(s)...
			var func = new Func<IActionResult>(() => Ok(Mapper.Map<IEnumerable<UniqueViewModelBase>>(UniqueInformableEntityContextRepository.Get())));

			return Do(this.GetInfo(nameof(Get), "from", "repository"), "retrieving", func);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
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

								UniqueInformableEntityContextRepository.Update(uniqueViewModel);

								var saveChangesAsync = UniqueInformableEntityContextRepository.SaveChangesAsync();
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

			return await Do(this.GetInfo(nameof(Post), "to", "repository", uniqueViewModel), "posting", task);
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
		/// <remarks>
		/// Last modification:
		/// </remarks>
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

	}

}
