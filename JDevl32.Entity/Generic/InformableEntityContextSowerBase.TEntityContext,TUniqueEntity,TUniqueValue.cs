using JDevl32.Entity.Interface.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A(n) (generic) entity context sower (base class).
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
	public abstract class InformableEntityContextSowerBase<TEntityContext, TUniqueEntity, TUniqueValue>
		:
		InformableEntityContextSowerBase<TEntityContext>
		,
		IEntityContextSower<TEntityContext, TUniqueEntity, TUniqueValue>
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

#region Implementation of IEntityContextSower<out TEntityContext, TUniqueEntity, TUniqueValue>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<TUniqueEntity> IEntityContextSower<TEntityContext, TUniqueEntity, TUniqueValue>.Entity => Entity;

#endregion

		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected abstract IEnumerable<TUniqueEntity> Entity { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
			:
			base(entityContext, loggerFactory)
		{
		}

#endregion

#region Implementation of IEntityContextSower<out TEntityContext, TUniqueEntity, TUniqueValue>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public async Task Seed(DbSet<TUniqueEntity> dbSet)
		{
			Logger.LogInformation($"Seed {DisplayName}...");

			var @new = string.Empty;

			if (dbSet.Any())
			{
				Logger.LogInformation($"...{DisplayName} already seeded.");
			} // if
			else if (null != Entity && Entity.Any())
			{
				@new = "New ";

				await dbSet.AddRangeAsync(Entity);
				await EntityContext.SaveChangesAsync();
			} // else if

			Logger.LogInformation($"{@new}{DisplayName} count = {dbSet.Count()}.");
		}

#endregion

	}

}
