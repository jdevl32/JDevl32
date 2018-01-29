using JDevl32.Entity.Interface;

namespace JDevl32.Entity.Extension
{

	/// <summary>
	/// An extension to the entity item (interface).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class Entity
	{

		/// <summary>
		/// Get a string representation of an entity item.
		/// </summary>
		/// <param name="entity">
		/// The entity item.
		/// </param>
		/// <returns>
		/// A string representation of the entity item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(this IEntity entity) => Common.ToString(entity);

	}

}
