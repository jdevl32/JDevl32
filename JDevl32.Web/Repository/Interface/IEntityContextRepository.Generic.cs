using JDevl32.Entity.Model;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Rename.
	/// Re-implement as generic.
	/// Add entity context.
	/// </remarks>
	public interface IEntityContextRepository<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

		/// <summary>
		/// The entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		//IEntityContext EntityContext { get; }

		EntityContextBase<TDerivedClass> EntityContext { get; }

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
