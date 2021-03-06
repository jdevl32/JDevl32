﻿using System.Threading.Tasks;

namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// A sower (seeder) for the entity context.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement logger downstream (due to loggable interface).
	/// </remarks>
	public interface IEntityContextSower
	{

#region Property

		/// <summary>
		/// An entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Remove generic entity context interface -- obsolete due to (new) loggable interface.
		/// </remarks>
		IEntityContext EntityContext { get; }

#endregion

		/// <summary>
		/// Seed the context.
		/// </summary>
		/// <returns>
		/// A task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task Seed();

	}

}
