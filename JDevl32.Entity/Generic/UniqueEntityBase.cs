using JDevl32.Entity.Interface.Generic;

namespace JDevl32.Entity.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A unique entity item (base class).
	/// </summary>
	/// <typeparam name="T">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class UniqueEntityBase<T>
		:
		IUniqueEntity<T>
		where
			T
			:
			struct
	{

#region Implementation of IUnique<T>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public T Id { get; set; }

#endregion

#region Implementation of IEntity

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string Description { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string FullName { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string ShortName { get; set; }

#endregion

	}

}
