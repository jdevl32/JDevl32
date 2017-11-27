using AutoMapper;

namespace JDevl32.Mapper.Interface
{

	/// <summary>
	/// An instance-base auto-mapper.
	/// </summary>
	public interface IInstanceMapper
	{

#region Property

		/// <summary>
		/// The auto-mapper instance.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IMapper Mapper { get; }

#endregion

	}

}
