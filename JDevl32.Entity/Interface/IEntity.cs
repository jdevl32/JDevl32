using System.ComponentModel.DataAnnotations;

namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// An entity item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntity
	{

#region Property

		/// <summary>
		/// A description for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string Description { get; set; }

		/// <summary>
		/// The full name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[Required]
		string FullName { get; set; }

		/// <summary>
		/// The short name of the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[Required]
		string ShortName { get; set; }

#endregion

	}

}
