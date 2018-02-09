using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDevl32.Entity.Interface.Generic
{

	/// <summary>
	/// A (generic) unique item.
	/// </summary>
	/// <typeparam name="T">
	/// The (value) type of the unique item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUnique<T>
		where
			T
			:
			struct
	{

#region Property

#region EF - Primary Key

		/// <summary>
		/// A unique (generic) identifier for the unique item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Required]
		T Id { get; set; }

#endregion

#endregion

	}

}
