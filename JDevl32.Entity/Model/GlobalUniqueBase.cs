using System;

namespace JDevl32.Entity.Model
{

	/// <inheritdoc />
	/// <summary>
	/// Global unique (entity) item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class GlobalUniqueBase
		:
		UniqueBase
	{

#region Overrides of UniqueBase

		/// <summary>
		/// The global unique identifier.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public new Guid Id { get; }

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
