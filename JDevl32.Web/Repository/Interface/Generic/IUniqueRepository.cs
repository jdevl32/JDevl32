using JDevl32.Entity.Model;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement as (generic) HTTP repository.
	/// </remarks>
	public interface IUniqueRepository<TUnique>
		:
		IHttpRepository<TUnique>
		where
			TUnique
			:
			UniqueBase
	{

#region Property

		// todo|jdevl32: how to best handle these (is new/override required) ???
		/**
		/// <summary>
		/// The db-set of (all) the (unique) entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		new DbSet<TUnique> EntityDbSet { get; }

		/// <summary>
		/// The db-set of (all) the unique item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		DbSet<TUnique> UniqueDbSet { get; }
		/**/

#endregion

		// todo|jdevl32: cleanup...
		/**
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
		/**/

	}

}
