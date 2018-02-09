using JDevl32.Logging.Interface;
using System.Threading.Tasks;

namespace JDevl32.Entity.Interface
{

	/// <inheritdoc />
	/// <summary>
	/// An informable entity context sower (interface).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableEntityContextSower
		:
		IInformable
	{

		/// <summary>
		/// Try (and catch any/all exception(s)) to seed the entity context.
		/// </summary>
		/// <returns>
		/// A (boolean) task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<bool> TrySeed();

	}

}
