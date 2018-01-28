using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A (generic) entity repository.
	/// </summary>
	/// <typeparam name="TEntity">
	/// The entity type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IHttpRepository<TEntity>
		where
			TEntity
			:
			class
	{

#region Property

		/// <summary>
		/// The db-set of (all) the entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		DbSet<TEntity> EntityDbSet { get; }

#endregion

		/// <summary>
		/// Get (all) the entity item(s).
		/// </summary>
		/// <returns>
		/// (All) the entity item(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<TEntity> Get();

		/// <summary>
		/// Remove (all) the entity item(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove();

		/// <summary>
		/// Remove the entity item.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void Remove(TEntity entity);

		/// <summary>
		/// Update the entity item.
		/// </summary>
		/// <remarks>
		/// Update is either add or modify (depending on existence).
		/// Last modification:
		/// </remarks>
		void Update(TEntity entity);

	}

}
