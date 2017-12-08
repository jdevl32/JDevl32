using JDevl32.Entity.Interface;
using System.ComponentModel.DataAnnotations;

namespace JDevl32.Entity.Model
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// Add default (parameterless) consctructor (required by Entity Framework).
	/// </remarks>
	public abstract class UniqueBase
		:
		IUnique
	{

#region IUnique

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[Key]
		[Required]
		public virtual int Id { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string ShortName { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string FullName { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string Description { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a unique item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected UniqueBase()
		{
		}

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
