using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Web.Controller.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Replace method to get a db-set of (all) the unique item entity items(s) with property.
	/// </remarks>
	public interface IUniqueRepository
	{

#region Property

		/// <summary>
		/// A unique item controller.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueController UniqueController { get; set; }

		/// <summary>
		/// The db-set of (all) the unique item entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		DbSet<UniqueBase> UniqueDbSet { get; }

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
		IEnumerable<IUnique> Get();

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
		void Remove(IUnique uniqueItem);

		/// <summary>
		/// Update the unique item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// </remarks>
		void Update(IUnique uniqueItem);

	}

}
