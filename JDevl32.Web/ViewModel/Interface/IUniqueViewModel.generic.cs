using JDevl32.Entity.Interface;
using JDevl32.Mapper.Interface;

namespace JDevl32.Web.ViewModel.Interface
{

	/// <inheritdoc />
	/// <summary>
	/// A unique item view model for a revolving credit account.
	/// </summary>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IUniqueViewModel<TUnique>
		// todo|jdevl32 ??? not possible (without actual interface) ???
		:
		//TUnique
		//,
		IInstanceMapper
		where
			TUnique
			:
			//interface
			//,
			IUnique
	{

#region Property

#endregion

		/// <summary>
		/// Map (this) view model to a unique item (using instance mapper).
		/// </summary>
		/// <returns>
		/// A unique item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		TUnique Map();

		// todo|jdevl32: not needed ???
		/**
		/// <summary>
		/// Map a unique item to a view model (using instance mapper).
		/// </summary>
		/// <param name="uniqueItem">
		/// The unique item.
		/// </param>
		/// <returns>
		/// A unique item view model.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IUniqueViewModel<TUnique> Map(TUnique uniqueItem);
		/**/

	}

}
