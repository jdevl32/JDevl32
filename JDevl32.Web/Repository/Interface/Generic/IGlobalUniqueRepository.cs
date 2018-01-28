using JDevl32.Entity.Model;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A (generic, global) unique item repository.
	/// </summary>
	/// <typeparam name="TGlobalUnique">
	/// The (global) unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IGlobalUniqueRepository<TGlobalUnique>
		:
		IHttpRepository<TGlobalUnique>
		where
			TGlobalUnique
			:
			GlobalUniqueBase
	{

#region Property

		// todo|jdevl32: how to best handle these (is new/override required) ???
		/**
		/// <summary>
		/// The db-set of (all) the (global unique) entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		new DbSet<TGlobalUnique> EntityDbSet { get; }

		/// <summary>
		/// The db-set of (all) the (global) unique item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		DbSet<TGlobalUnique> GlobalUniqueDbSet { get; }
		/**/

#endregion

	}

}
