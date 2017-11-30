using System.ComponentModel.DataAnnotations;

namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// A unique (entity) item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add setters (required by Entity Framework).
	/// </remarks>
	public interface IUnique
	{

#region Property

#region EF - Primary Key

		/// <summary>
		/// A unique identifier for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[Key]
		[Required]
		int Id { get; set; }

#endregion

		/// <summary>
		/// The short name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string ShortName { get; set; }

		/// <summary>
		/// The full name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string FullName { get; set; }

		/// <summary>
		/// A description for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string Description { get; set; }

#endregion

	}

}
