using JDevl32.Entity.Interface;
using System.ComponentModel.DataAnnotations;

namespace JDevl32.Entity.Model
{

	/// <inheritdoc />
	/// <summary>
	/// Unique (entity) item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class UniqueBase
		:
		IUnique
	{

#region IUnique

		/// <inheritdoc />
		[Key]
		[Required]
		public virtual int Id { get; set; }

		/// <inheritdoc />
		public string ShortName { get; }

		/// <inheritdoc />
		public string FullName { get; }

		/// <inheritdoc />
		public string Description { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a unique item.
		/// </summary>
		/// <param name="id">
		/// The unique identifier.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected UniqueBase(int id) => Id = id;

		/// <inheritdoc />
		/// <summary>
		/// Create a unique item.
		/// </summary>
		/// <param name="id">
		/// The unique identifier.
		/// </param>
		/// <param name="shortName">
		/// The short name.
		/// </param>
		/// <param name="fullName">
		/// The full (long) name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected UniqueBase(int id, string shortName, string fullName, string description)
			:
			this(shortName, fullName, description) => Id = id;

		/// <summary>
		/// Create a unique item.
		/// </summary>
		/// <param name="shortName">
		/// The short name.
		/// </param>
		/// <param name="fullName">
		/// The full (long) name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected UniqueBase(string shortName, string fullName, string description)
		{
			ShortName = shortName;
			FullName = fullName;
			Description = description;
		}

#endregion

	}

}
