namespace JDevl32.Logging.Interface.Generic
{

	/// <inheritdoc />
	/// <summary>
	/// An informable object.
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInformable<out TDerivedClass>
		:
		ILoggable<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string DisplayName { get; }

#endregion

	}

}
