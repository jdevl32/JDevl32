using JDevl32.Entity.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) unique entity item repository.
	/// </summary>
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
	public interface IUniqueEntityRepository<TUniqueEntity, TUniqueValue>
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

		/// <summary>
		/// The db-set of (all) the unique entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		DbSet<TUniqueEntity> UniqueEntityDbSet { get; }

#endregion

		/// <summary>
		/// Get (all) the unique entity item(s).
		/// </summary>
		/// <returns>
		/// (All) the unique entity item(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		IEnumerable<TUniqueEntity> Get();

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
		/// Add the type of the unique entity item.
		/// </remarks>
		void Remove(TUniqueEntity uniqueEntity);

		/// <summary>
		/// Update the unique entity item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		void Update(TUniqueEntity uniqueEntity);

	}

}
