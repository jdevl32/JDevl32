using Microsoft.Extensions.Logging;

namespace JDevl32.Logging.Interface.Generic
{

	/// <summary>
	/// A (generic) loggable object.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Make (derived class) type covariant.
	/// </remarks>
	public interface ILoggable<out TDerivedClass>
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
