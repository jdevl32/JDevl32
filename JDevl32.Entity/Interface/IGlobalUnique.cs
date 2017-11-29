using System;
using System.ComponentModel.DataAnnotations;

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
		/// </remarks>
		[Key]
		[Required]
		new Guid Id { get; }

#endregion

#endregion

	}

}
