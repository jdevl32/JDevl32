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
		/// Correct HTTP method attribute specification(s).
		/// </remarks>
		[HttpDelete("*", Name = "RemoveAll")]
		public virtual async Task<IActionResult> Delete()
		{
			try
			{
				if (ModelState.IsValid)
				{
					UniqueEntityContextRepository.Remove();

					if (await UniqueEntityContextRepository.SaveChangesAsync())
					{
						return Ok();
					} // if
				} // if
				else if (HostingEnvironment.IsDevelopment())
				{
					return BadRequest(ModelState);
				} // if
			} // try
			catch (Exception exception)
			{
				Logger.LogError($"Error removing (all) the {DisplayName}(s) from the repository:  {exception}");
			} // catch

			return BadRequest();
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add (missing) HTTP method attribute specification(s).
		/// </remarks>
		[HttpDelete]
		public virtual async Task<IActionResult> Delete(UniqueViewModelBase uniqueViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					// todo|jdevl32: ???
					//uniqueViewModel.UserName = User.Identity.Name;

					UniqueEntityContextRepository.Remove(uniqueViewModel);

					if (await UniqueEntityContextRepository.SaveChangesAsync())
					{
						return Ok();
					} // if
				} // if
				else if (HostingEnvironment.IsDevelopment())
				{
					return BadRequest(ModelState);
				} // if
			} // try
			catch (Exception exception)
			{
				Logger.LogError($"Error removing the {DisplayName} ({uniqueViewModel}) from the repository:  {exception}");
			} // catch

			return BadRequest();
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add (missing) HTTP method attribute specification(s).
		/// </remarks>
		[HttpGet]
		public virtual IActionResult Get()
		{
			try
			{
				return Ok(Mapper.Map<IEnumerable<UniqueViewModelBase>>(UniqueEntityContextRepository.Get()));
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error retrieving (all) the {DisplayName}(s) from the repository:  {ex}");
			} // catch

			return BadRequest();
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add (missing) HTTP method attribute specification(s).
		/// </remarks>
		[HttpPost]
		public virtual async Task<IActionResult> Post(UniqueViewModelBase uniqueViewModel)
		{
			// todo|jdevl32: contant(s)...
			try
			{
				if (ModelState.IsValid)
				{
					//uniqueViewModel.UserName = User.Identity.Name;

					UniqueEntityContextRepository.Update(uniqueViewModel);

					if (await UniqueEntityContextRepository.SaveChangesAsync())
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
			} // try
			catch (Exception ex)
			{
				Logger.LogError($"Error posting the {DisplayName} ({uniqueViewModel}) to the repository:  {ex}");
			} // catch

			return BadRequest();
		}

#endregion

	}

}
