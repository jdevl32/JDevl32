using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Logging.Extension;
using JDevl32.Web.Controller.Interface.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using JDevl32.Web.ViewModel.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IInformable = JDevl32.Logging.Interface.IInformable;

namespace JDevl32.Web.Controller.Generic
{

	/// <summary>
	/// A(n) (generic) informable unique entity item controller (base class).
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item view model.
	/// </remarks>
	public abstract class InformableUniqueEntityControllerBase<TEntityContext, TUniqueEntity, TUniqueEntityViewModel, TUniqueValue>
		:
		ControllerBase
		,
		IInformable
		,
		IUniqueEntityController<TUniqueEntityViewModel, TUniqueValue>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
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

#region Implementation of IInformable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string IInformable.DisplayName
		{
			get => DisplayName;
			set => throw new NotImplementedException();
		}

#endregion

		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string DisplayName { get; }

		/// <summary>
		/// An informable unique entity item context repository.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, TUniqueValue> InformableUniqueEntityContextRepository { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, TUniqueValue> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, loggerFactory, mapper)
		{
			InformableUniqueEntityContextRepository = informableUniqueEntityContextRepository;

			// Set the display name (and the same for the repository).
			InformableUniqueEntityContextRepository.DisplayName = DisplayName = displayName;
		}

#endregion

#region Implementation of IUniqueEntityController<TUniqueEntityViewModel, TUniqueValue>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Remove name specification from http-delete attribute.
		/// </remarks>
		[HttpDelete("*")]
		public virtual async Task<IActionResult> Delete()
		{
			// todo|jdevl32: constant(s)...
			var task =
				new Func<Task<IActionResult>>
				(
					async () =>
					{
						if (ModelState.IsValid)
						{
							InformableUniqueEntityContextRepository.Remove();

							if (await InformableUniqueEntityContextRepository.SaveChangesAsync())
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
		/// Add the type of the unique entity item view model.
		/// </remarks>
		[HttpDelete]
		public virtual async Task<IActionResult> Delete([FromBody] TUniqueEntityViewModel uniqueEntityViewModel)
		{
			// todo|jdevl32: constant(s)...
			var task =
				new Func<Task<IActionResult>>
				(
					async () =>
					{
						if (ModelState.IsValid)
						{
							// todo|jdevl32: ???
							//uniqueEntityViewModel.UserName = User.Identity.Name;
							var uniqueEntity = Mapper.Map<TUniqueEntity>(uniqueEntityViewModel);

							InformableUniqueEntityContextRepository.Remove(uniqueEntity);

							if (await InformableUniqueEntityContextRepository.SaveChangesAsync())
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

			return await Do(this.GetInfo(nameof(Delete), "from", "repository", uniqueEntityViewModel), "removing", task);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item view model.
		/// </remarks>
		[HttpGet]
		public virtual IActionResult Get()
		{
			// todo|jdevl32: constant(s)...
			var method =
				new Func<IActionResult>
					(
						() =>
						Ok
							(
								Mapper.Map<IEnumerable<TUniqueEntityViewModel>>
									(
										InformableUniqueEntityContextRepository.Get()
									)
							)
					)
			;

			return Do(this.GetInfo(nameof(Get), "from", "repository"), "retrieving", method);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item view model.
		/// </remarks>
		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody] TUniqueEntityViewModel uniqueEntityViewModel)
		{
			// todo|jdevl32: constant(s)...
			var task =
				new Func<Task<IActionResult>>
				(
					async () =>
					{
						if (ModelState.IsValid)
						{
							// todo|jdevl32: ???
							//uniqueEntityViewModel.UserName = User.Identity.Name;
							var uniqueEntity = Mapper.Map<TUniqueEntity>(uniqueEntityViewModel);

							InformableUniqueEntityContextRepository.Update(uniqueEntity);

							if (await InformableUniqueEntityContextRepository.SaveChangesAsync())
							{
								// Use map in case database modified the unique entity item in any way.
								var value = Mapper.Map<TUniqueEntityViewModel>(uniqueEntity);
								// todo|jdevl32: ??? does this work for add/new ???
								return Accepted($"{Request.Path.Value}/{value.Id}", value);
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

			return await Do(this.GetInfo(nameof(Post), "to", "repository", uniqueEntityViewModel), "posting", task);
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
		protected virtual async Task<IActionResult> Do(string info, string action, Func<Task<IActionResult>> task)
		{
			try
			{
				return await task();
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
			} // catch

			return BadRequest();
		}

	}

}
