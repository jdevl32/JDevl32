using JDevl32.Entity.Interface.Generic;

namespace JDevl32.Entity.Extension
{

	/// <summary>
	/// An extension to the unique item (interface).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class Unique
	{

		/// <summary>
		/// Get a string representation of a unique item.
		/// </summary>
		/// <typeparam name="T">
		/// The (value) type of the unique item.
		/// </typeparam>
		/// <param name="unique">
		/// The unique item.
		/// </param>
		/// <returns>
		/// A string representation of the unique item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString<T>(this IUnique<T> unique)
			where
				T
				:
				struct
			=>
			Common.ToString(unique);

	}

}
