using AutoMapper;

namespace JDevl32.Entity.Interface
{

	/// <inheritdoc />
	/// <summary>
	/// An entity context with (an auto-mapper) mapper.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IMapperEntityContext
		:
		IEntityContext
	{

#region Property

		/// <summary>
		/// The mapper.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IMapper Mapper { get; }

#endregion

	}

}
