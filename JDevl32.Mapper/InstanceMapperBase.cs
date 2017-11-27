using AutoMapper;
using JDevl32.Mapper.Interface;

namespace JDevl32.Mapper
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InstanceMapperBase
		:
		IInstanceMapper
	{

#region Property

#region IInstanceMapper

		/// <inheritdoc />
		public IMapper Mapper { get; }

#endregion

#endregion

#region Instance Initialization

		/// <summary>
		/// Create an instance-based auto-mapper.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InstanceMapperBase(IMapper mapper) => Mapper = mapper;

#endregion

	}

}
