using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Web.Controller.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The unique item entity type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add unique item controller (for display name).
	/// Add method to get unique item entity db-set.
	/// Add unique item entity type.
	/// </remarks>
	public interface IUniqueRepository<TUnique, TUniqueEntity>
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

		/// <summary>
		/// A method that returns a db-set of (all) the unique item entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Func<DbSet<TUniqueEntity>> GetUniqueEntityDbSet { get; set; }

		/// <summary>
		/// A unique item controller.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueController<TUnique> UniqueController { get; set; }

#endregion

		/// <summary>
		/// Get the unique item(s).
		/// </summary>
		/// <returns>
		/// The unique item(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<TUnique> Get();

		/// <summary>
		/// Remove (all) the unique item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove();

		/// <summary>
		/// Remove the unique item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove(TUnique uniqueItem);

		/// <summary>
		/// Update the unique item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// </remarks>
		void Update(TUnique uniqueItem);

	}

}
