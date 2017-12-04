using JDevl32.Entity.Model;
using JDevl32.Logging.Interface;
using JDevl32.Web.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository
{

	/// <summary>
	/// The (generic) entity context repository (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextRepositoryBase<TDerivedClass>
		:
		IEntityContextRepository<TDerivedClass>
		,
		ILoggable<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

#region IEntityContextRepository

		/// <inheritdoc />
		public abstract EntityContextBase<TDerivedClass> EntityContext { get; }

#endregion

#endregion

#region ILoggable<TDerivedClass>

		/// <inheritdoc />
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#region IEntityContextRepository

		/// <inheritdoc />
		public virtual async Task<bool> SaveChangesAsync() => await EntityContext.SaveChangesAsync() > 0;

#endregion

	}

}
