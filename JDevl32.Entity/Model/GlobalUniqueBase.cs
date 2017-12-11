using JDevl32.Entity.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDevl32.Entity.Model
{

	/// <summary>
	/// Global unique (entity) item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Re-implement with (new) interface.
	/// </remarks>
	public abstract class GlobalUniqueBase
		:
		UniqueBase
		,
		IGlobalUnique
	{

#region IGlobalUnique

		/// <inheritdoc />
		/// <summary>
		/// The global unique identifier.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add database generated identity annotation.
		/// </remarks>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Required]
		public new Guid Id { get; set; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create a global unique (entity) item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected GlobalUniqueBase()
			:
			this(Guid.NewGuid())
		{
		}

		/// <inheritdoc />
		protected GlobalUniqueBase(Guid id)
			:
			base(id.GetHashCode()) => Id = id;

		/// <inheritdoc />
		protected GlobalUniqueBase(Guid id, string shortName, string fullName, string description)
			:
			base(id.GetHashCode(), shortName, fullName, description) => Id = id;

#endregion

	}

}
