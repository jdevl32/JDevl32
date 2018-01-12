using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Web.ViewModel.Interface;

namespace JDevl32.Web.ViewModel
{

	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Inherit unique (item) (base class).
	/// </remarks>
	public abstract class UniqueViewModelBase<TUnique>
		:
		UniqueBase
		,
		// todo|jdevl32 ??? not possible (without actual interface) ???
		//TUnique
		//,
		//IUnique
		//,
		IUniqueViewModel<TUnique>
		where
			TUnique
			:
			//interface
			//,
			IUnique
	{

#region Property

#region IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual IMapper Mapper { get; }

#endregion

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a unique item view model.
		/// </summary>
		/// <param name="mapper">
		/// The instance mapper.
		/// </param>
		protected UniqueViewModelBase(IMapper mapper) => Mapper = mapper;

#endregion

#region IUniqueViewModel<TUnique>

		/// <inheritdoc />
		/// <returns>
		/// A unique item.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual TUnique Map() => Mapper.Map<TUnique>(this);

		// todo|jdevl32: not needed ???
		/**
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IUniqueViewModel<TUnique> Map(TUnique uniqueItem) => Mapper.Map<IUniqueViewModel<TUnique>>(uniqueItem);
		/**/

#endregion

	}

}
