using Microsoft.Extensions.Logging;

namespace JDevl32.Logging.Interface.Generic
{

	/// <summary>
	/// A(n) (generic) informable object.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement (as derived from (non-generic) informable interface).
	/// </remarks>
	public interface IInformable<out TDerivedClass>
		:
		// todo|jdevl32: ambiguous ???
		IInformable
		,
		ILoggable<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

		// todo|jdevl32: see above ???
		/**
		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add/refactor setter.
		/// </remarks>
		string DisplayName { get; set; }
		/**/

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		new ILogger Logger { get; }

#endregion

	}

}
