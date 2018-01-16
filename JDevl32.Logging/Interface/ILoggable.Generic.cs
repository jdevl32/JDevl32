using Microsoft.Extensions.Logging;

namespace JDevl32.Logging.Interface
{

	// todo|jdevl32: make covariant ???
	/// <summary>
	/// A (generic) loggable object.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface ILoggable<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ILogger<TDerivedClass> Logger { get; }

#endregion

	}

}
