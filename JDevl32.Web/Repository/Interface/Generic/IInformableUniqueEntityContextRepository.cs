﻿using JDevl32.Entity.Generic;
using JDevl32.Logging.Interface;

namespace JDevl32.Web.Repository.Interface.Generic
{

	/// <summary>
	/// A(n) (generic) informable unique entity item context repository.
	/// </summary>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Refactor loggable logger category name.
	/// </remarks>
	public interface IInformableUniqueEntityContextRepository<TUniqueEntity, TUniqueValue>
		:
		IEntityContextRepository
		,
		IInformable
		,
		IUniqueEntityRepository<TUniqueEntity, TUniqueValue>
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{
	}

}
