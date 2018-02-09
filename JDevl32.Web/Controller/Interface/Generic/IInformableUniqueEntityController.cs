using JDevl32.Web.ViewModel.Generic;
using IInformable = JDevl32.Logging.Interface.IInformable;

namespace JDevl32.Web.Controller.Interface.Generic
{

	// todo|jdevl32: entity context and unique entity type(s) ???
	/// <summary>
	/// A(n) (generic) informable unique entity item controller (base class).
	/// </summary>
	/**
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/**/
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueEntityController</**TEntityContext, TUniqueEntity, /**/in TUniqueEntityViewModel, TUniqueValue>
		:
		IInformable
		,
		IUniqueEntityController<TUniqueEntityViewModel, TUniqueValue>
		/**
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		/**/
		where
			TUniqueEntityViewModel
			:
			UniqueEntityViewModelBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{
	}

}
