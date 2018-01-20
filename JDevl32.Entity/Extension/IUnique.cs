namespace JDevl32.Entity.Extension
{

	/// <summary>
	/// An extension to the unique item interface.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class IUnique
	{

		/// <summary>
		/// Get a string representation of a unique item.
		/// </summary>
		/// <param name="uniqueItem">
		/// The unique item.
		/// </param>
		/// <returns>
		/// A string representation of the unique item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(this Interface.IUnique uniqueItem) => Common.ToString(uniqueItem);

	}

}
