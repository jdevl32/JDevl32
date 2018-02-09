using JDevl32.Web.ViewModel.Generic;

namespace JDevl32.Web.Controller.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// A(n) (generic) informable unique (integer) identifier entity item controller (base class).
	/// </summary>
	/// <typeparam name="TUniqueEntityViewModel">
	/// The type of the unique entity item view model.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformableUniqueIntEntityController<in TUniqueEntityViewModel>
		:
		IInformableUniqueEntityController<TUniqueEntityViewModel, int>
		where
			TUniqueEntityViewModel
			:
			// todo|jdevl32: replace with (int) type-specific ???
			UniqueEntityViewModelBase<int>
	{
	}

}
