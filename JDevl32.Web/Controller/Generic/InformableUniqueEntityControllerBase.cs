using AutoMapper;
using JDevl32.Entity.Generic;
using JDevl32.Logging.Extension;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Web.Controller.Interface.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using JDevl32.Web.ViewModel.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDevl32.Web.Controller.Generic
{

	/// <summary>
	/// A unique entity item controller (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TRepository">
	/// This should be the type of the derived class of the repository (for the logger).
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item.
	/// </remarks>
	public abstract class InformableUniqueEntityControllerBase<TDerivedClass, TRepository, TUniqueEntity, TUniqueValue>
		:
		ControllerBase<TDerivedClass>
		,
		IInformable<TDerivedClass>
		,
		IUniqueEntityController<TUniqueValue>
		where
			TDerivedClass
			:
			class
		where
			TRepository
			:
			class
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{

#region Property

#region Implementation of IInformable<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string IInformable<TDerivedClass>.DisplayName
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
		/// Add the type of the unique entity item.
		/// </remarks>
		public virtual IInformableUniqueEntityContextRepository<TRepository, TUniqueEntity, TUniqueValue> InformableUniqueEntityContextRepository { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected InformableUniqueEntityControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper, IInformableUniqueEntityContextRepository<TRepository, TUniqueEntity, TUniqueValue> informableUniqueEntityContextRepository, string displayName)
			:
			base(hostingEnvironment, logger, mapper)
		{
			InformableUniqueEntityContextRepository = informableUniqueEntityContextRepository;

			// Set the display name (and the same for the repository).
			InformableUniqueEntityContextRepository.DisplayName = DisplayName = displayName;
		}

#endregion

#region Implementation of IUniqueEntityController<TUniqueValue>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpDelete("*", Name = "RemoveAll")]
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
		/// Add the type of the unique entity item.
		/// </remarks>
		[HttpDelete]
		public virtual async Task<IActionResult> Delete([FromBody] UniqueEntityViewModelBase<TUniqueValue> uniqueEntityViewModel)
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
								Mapper.Map<IEnumerable<UniqueEntityViewModelBase<TUniqueValue>>>(InformableUniqueEntityContextRepository.Get())
							)
					)
			;

			return Do(this.GetInfo(nameof(Get), "from", "repository"), "retrieving", method);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody] UniqueEntityViewModelBase<TUniqueValue> uniqueEntityViewModel)
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
								var value = Mapper.Map<UniqueEntityViewModelBase<TUniqueValue>>(uniqueEntity);
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
