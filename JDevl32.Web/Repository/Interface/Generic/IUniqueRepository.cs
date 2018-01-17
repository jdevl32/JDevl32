using JDevl32.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add unique item type.
	/// </remarks>
	public interface IUniqueRepository<TUnique>
		where
			TUnique
			:
			UniqueBase
	{

#region Property

		/// <summary>
		/// The db-set of (all) the unique item entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		DbSet<TUnique> UniqueDbSet { get; }

#endregion

		/// <summary>
		/// Get (all) the unique item(s).
		/// </summary>
		/// <returns>
		/// (All) the unique item(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
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
		/// Add unique item type.
		/// </remarks>
		void Remove(TUnique uniqueItem);

		/// <summary>
		/// Update the unique item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		void Update(TUnique uniqueItem);

	}

}
