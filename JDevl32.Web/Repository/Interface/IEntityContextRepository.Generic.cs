using JDevl32.Entity;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Interface
{

	/// <summary>
	/// A (generic) entity context repository.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
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
