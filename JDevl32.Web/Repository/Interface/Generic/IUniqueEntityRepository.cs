using JDevl32.Entity.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) unique entity item repository.
	/// </summary>
	/// <typeparam name="T">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueEntityRepository<T>
		where
			T
			:
			struct
	{

#region Property

		/// <summary>
		/// The db-set of (all) the unique entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		DbSet<UniqueEntityBase<T>> UniqueEntityDbSet { get; }

#endregion

		/// <summary>
		/// Get (all) the unique entity item(s).
		/// </summary>
		/// <returns>
		/// (All) the unique entity item(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<UniqueEntityBase<T>> Get();

		/// <summary>
		/// Remove (all) the unique entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove();

		/// <summary>
		/// Remove the unique entity item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove(UniqueEntityBase<T> uniqueEntity);

		/// <summary>
		/// Update the unique entity item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// Add unique entity item type.
		/// </remarks>
		void Update(UniqueEntityBase<T> uniqueEntity);

	}

}
