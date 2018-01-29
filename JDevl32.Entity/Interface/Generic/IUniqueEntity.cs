namespace JDevl32.Entity.Interface.Generic
{

	/// <summary>
	/// A (generic) unique entity item.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueEntity<T>
		:
		IEntity
		,
		IUnique<T>
		where
			T
			:
			struct
	{
	}

}
