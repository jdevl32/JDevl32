using JDevl32.Entity;
using JDevl32.Entity.Generic;
using System;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A(n) (generic) informable unique (GUID) identifier entity item context repository (interface).
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueGuidEntityContextRepository<out TEntityContext, TUniqueEntity>
		:
		IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, Guid>
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			// todo|jdevl32: replace with (guid) type-specific ???
			UniqueEntityBase<Guid>
	{
	}

}
