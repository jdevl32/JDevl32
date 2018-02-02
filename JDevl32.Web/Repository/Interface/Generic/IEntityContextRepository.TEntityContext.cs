using JDevl32.Entity;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A(n) (generic) entity context repository.
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntityContextRepository<out TEntityContext>
		where
			TEntityContext
			:
			EntityContextBase
	{

#region Property

		/// <summary>
		/// The entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		TEntityContext EntityContext { get; }

#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<bool> SaveChangesAsync();

	}

}
