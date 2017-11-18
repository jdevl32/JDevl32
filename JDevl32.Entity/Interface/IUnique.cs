namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// A unique entity.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUnique
	{

#region Property

		/// <summary>
		/// A unique identifier for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		int Id { get; }

		/// <summary>
		/// The short name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string ShortName { get; }

		/// <summary>
		/// The full name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string FullName { get; }

		/// <summary>
		/// A description for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string Description { get; }

#endregion

	}

}
