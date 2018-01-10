using JDevl32.Entity.Interface;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) unique item repository.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueRepository<TUnique>
		where
			TUnique
			:
			IUnique
	{

#region Property

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
		void Remove(TUnique apr);

		/// <summary>
		/// Update the unique item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// </remarks>
		void Update(TUnique apr);

#endregion

	}

}
