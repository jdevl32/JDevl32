using JDevl32.Entity.Interface;

namespace JDevl32.Entity
{

	/// <summary>
	/// A common (utility) class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class Common
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
		public static string ToString(IUnique uniqueItem) => $"[{nameof(uniqueItem.Id)}={uniqueItem.Id}|{nameof(uniqueItem.ShortName)}={uniqueItem.ShortName}|{nameof(uniqueItem.FullName)}={uniqueItem.FullName}|{nameof(uniqueItem.Description)}={uniqueItem.Description}]";

	}

}
