using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Web.Controller.Interface;
using JDevl32.Web.Repository.Interface;
using JDevl32.Web.ViewModel.Interface;
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
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The unique item entity type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add unique item entity type.
	/// </remarks>
	public abstract class UniqueEntityContextControllerBase<TDerivedClass, TUnique, TUniqueEntity>
		:
		ControllerBase<TDerivedClass>
		,
		IUniqueController<TUnique>
		where
			TDerivedClass
			:
			class
		where
			TUnique
			:
			IUnique
		where
			TUniqueEntity
			:
			UniqueBase
	{

#region Property

#region IUniqueController<TUnique>

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
		public virtual IUniqueEntityContextRepository<TUnique, TUniqueEntity> UniqueEntityContextRepository { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Remove derived class type from unique entity context repository.
		/// Add unique item entity type to unique entity context repository.
		/// </remarks>
		protected UniqueEntityContextControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper,  IUniqueEntityContextRepository<TUnique, TUniqueEntity> uniqueEntityContextRepository, string displayName)
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
		/// </remarks>
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
		/// </remarks>
		public virtual async Task<IActionResult> Delete(IUniqueViewModel<TUnique> uniqueViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var uniqueItem = uniqueViewModel.Map();
					//uniqueItem.UserName = User.Identity.Name;

					UniqueEntityContextRepository.Remove(uniqueItem);

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
		/// </remarks>
		public virtual IActionResult Get()
		{
			try
			{
				return Ok(Mapper.Map<IEnumerable<IUniqueViewModel<TUnique>>>(UniqueEntityContextRepository.Get()));
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
		/// </remarks>
		public virtual async Task<IActionResult> Post(IUniqueViewModel<TUnique> uniqueViewModel)
		{
			// todo|jdevl32: contant(s)...
			try
			{
				if (ModelState.IsValid)
				{
					var uniqueItem = uniqueViewModel.Map();
					//uniqueItem.UserName = User.Identity.Name;

					UniqueEntityContextRepository.Update(uniqueItem);

					if (await UniqueEntityContextRepository.SaveChangesAsync())
					{
						// todo|jdevl32: !!! revisit this !!!
						/**
						// Use map in case database modified the unique item in any way.
						var value = Mapper.Map<IUniqueViewModel<TUnique>>(uniqueItem);

						return Accepted($"{Request.Path.Value}/{value.Id}", value);
						/**/
						// todo|jdevl32: ??? does this work for add/new ???
						return Accepted($"{Request.Path.Value}/{uniqueItem.Id}", uniqueItem);
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
