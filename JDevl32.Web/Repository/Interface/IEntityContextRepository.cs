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

		/// <summary>
		/// The entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEntityContext EntityContext { get; }

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
