namespace JDevl32.Logging.Interface
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// (Re-)implement (as (non-generic) loggable interface).
	/// </remarks>>
	public interface IInformable
		:
		ILoggable
	{

#region Property

		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string DisplayName { get; set; }

#endregion

	}

}
