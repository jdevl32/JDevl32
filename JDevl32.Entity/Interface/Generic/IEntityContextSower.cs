using System.Threading.Tasks;

namespace JDevl32.Entity.Interface.Generic
{

	/// <summary>
	/// A sower (seeder) for an entity context.
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntityContextSower<out TEntityContext>
		where
			TEntityContext
			:
			EntityContextBase
	{

#region Property

		/// <summary>
		/// An entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		TEntityContext EntityContext { get; }

#endregion

		/// <summary>
		/// Seed the context.
		/// </summary>
		/// <returns>
		/// A task.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task Seed();

	}

}
