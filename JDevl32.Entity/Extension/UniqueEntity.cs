using JDevl32.Entity.Interface.Generic;

namespace JDevl32.Entity.Extension
{

	/// <summary>
	/// An extension to the unique entity item (interface).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class UniqueEntity
	{

		/// <summary>
		/// Get a string representation of a unique entity item.
		/// </summary>
		/// <typeparam name="T">
		/// The (value) type of the unique entity item.
		/// </typeparam>
		/// <param name="uniqueEntity">
		/// The unique entity item.
		/// </param>
		/// <returns>
		/// A string representation of the unique entity item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString<T>(this IUniqueEntity<T> uniqueEntity)
			where
				T
				:
				struct
			=>
			// todo|jdevl32: !!! this needs to be revisited !!!
			//Common.ToString(uniqueEntity as IUnique<T>, uniqueEntity as IEntity);
			Common.ToString(uniqueEntity);

	}

}
