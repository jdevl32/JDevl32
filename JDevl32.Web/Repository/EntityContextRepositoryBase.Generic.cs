using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using JDevl32.Mapper.Interface;
using JDevl32.Web.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository
{

	/// <summary>
	/// The (generic) entity context repository (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add entity context type parameter.
	/// Implement instance mapper.
	/// Add constructor.
	/// </remarks>
	public abstract class EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		:
		IEntityContextRepository
		,
		ILoggable<TDerivedClass>
		,
		IInstanceMapper
		where
			TDerivedClass
			:
			class
		where
			TEntityContext
			:
			IEntityContext
	{

#region Property

#region IEntityContextRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Re-implement explicitly.
		/// </remarks>
		IEntityContext IEntityContextRepository.EntityContext
		{
			get => Mapper.Map<IEntityContext>(EntityContext);
			// todo|jdevl32: is the setter needed ???
		}

#endregion

#region ILoggable<TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#region IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IMapper Mapper { get; }

#endregion

		/// <summary>
		/// The entity context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual TEntityContext EntityContext { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create an entity context repository.
		/// </summary>
		/// <param name="entityContext">
		/// The entity context.
		/// </param>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper)
		{
			EntityContext = entityContext;
			Logger = logger;
			Mapper = mapper;
		}

#endregion

#region IEntityContextRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<bool> SaveChangesAsync() => await EntityContext.SaveChangesAsync() > 0;

#endregion

	}

}
