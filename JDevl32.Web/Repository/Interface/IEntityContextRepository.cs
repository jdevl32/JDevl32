using JDevl32.Entity.Interface;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// An entity context repository.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntityContextRepository
	{

#region Property

		// todo|jdevl32: ??? should this be entity-context-base (abstract base class instead of interface) ???
		/// <summary>
		/// An entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEntityContext EntityContext { get; }

#endregion

		/// <summary>
		/// Save changes to the database (via the entity context repository) asynchronously.
		/// </summary>
		/// <returns>
		/// A task (of (a) boolean).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<bool> SaveChangesAsync();

	}

}
