using JDevl32.Web.ViewModel.Generic;
using System;

namespace JDevl32.Web.Controller.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A(n) (generic) informable unique (GUID) identifier entity item controller (base class).
	/// </summary>
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueGuidEntityController<in TUniqueEntityViewModel>
		:
		IInformableUniqueEntityController<TUniqueEntityViewModel, Guid>
		where
			TUniqueEntityViewModel
			:
			// todo|jdevl32: replace with (guid) type-specific ???
			UniqueEntityViewModelBase<Guid>
	{
	}

}
