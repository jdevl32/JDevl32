using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDevl32.Entity.Interface
{

	/// <inheritdoc />
	/// <summary>
	/// A global unique entity.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IGlobalUnique
		:
		IUnique
	{

#region Property

#region EF - Primary Key

		/// <summary>
		/// A global unique identifier for the entity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add database generated identity annotation.
		/// </remarks>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Required]
		new Guid Id { get; }

#endregion

#endregion

	}

}
