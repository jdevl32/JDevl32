using AutoMapper;

namespace JDevl32.Mapper.Interface
{

	/// <summary>
	/// An instance-based auto-mapper.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IInstanceMapper
	{

#region Property

		/// <summary>
		/// An auto-mapper instance.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IMapper Mapper { get; }

#endregion

	}

}
