using JDevl32.Entity.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDevl32.Entity.Model
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// Add to-string override.
	/// </remarks>
	public abstract class UniqueBase
		:
		IUnique
	{

#region IUnique

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add database generated identity annotation.
		/// </remarks>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

#endregion

#region Object

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public override string ToString() => $"[{base.ToString()}|{Extension.IUnique.ToString(this)}]";

#endregion

	}

}
