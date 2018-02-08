using JDevl32.Entity.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDevl32.Entity.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A sower (seeder) for an entity context.
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntityContextSower<out TEntityContext, TUniqueEntity, TUniqueValue>
		:
		IEntityContextSower<TEntityContext>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{

#region Property

		/// <summary>
		/// The unique entity item(s) to sow (seed).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<TUniqueEntity> Entity { get; }

#endregion

		/// <summary>
		/// Seed the context (with a set of unique entity item(s)).
		/// </summary>
		/// <param name="dbSet">
		/// A set of unique entity item(s).
		/// </param>
		/// <returns>
		/// A task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task Seed(DbSet<TUniqueEntity> dbSet);

	}

}
