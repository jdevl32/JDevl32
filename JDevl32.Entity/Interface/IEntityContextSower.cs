using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// The sower (seeder) for the entity context.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Re-implement
	/// </remarks>
	public interface IEntityContextSower
	{

#region Property

		/// <summary>
		/// The entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEntityContext<IEntityContextSower> EntityContext { get; }

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ILogger<IEntityContextSower> Logger { get; }

#endregion

		/// <summary>
		/// Seed the context.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task Seed();

	}

}
