using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Remove unique item controller.
	/// </remarks>
	public interface IUniqueRepository
	{

#region Property

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
