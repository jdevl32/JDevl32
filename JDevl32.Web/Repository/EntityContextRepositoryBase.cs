using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using JDevl32.Web.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository
{

	/// <summary>
	/// An entity context repository (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextRepositoryBase
		:
		IEntityContextRepository
		,
		ILoggable
		// todo|jdevl32: ???
		/**
		,
		IInstanceMapper
		/**/
	{

#region Property

#region Implementation of IEntityContextRepository

		// todo|jdevl32: ???
		/**
		// todo|jdevl32: ??? is the setter needed ???
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// (Re-)implement explicitly.
		/// </remarks>
		IEntityContext IEntityContextRepository.EntityContext => Mapper.Map<IEntityContext>(EntityContext);
		/**/

		// todo:jdevl32: ??? should this be entity-context-base (abstract base class instead of interface) ???
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual IEntityContext EntityContext { get; }

#endregion

#region Implementation of ILoggable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual ILogger Logger { get; }

#endregion

		// todo|jdevl32: ???
		/**
#region Implementation of IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IMapper Mapper { get; }

#endregion
		/**/

#endregion

#region Instance Initialization

		/// <summary>
		/// Create an entity context repository.
		/// </summary>
		/// <param name="entityContext">
		/// An entity context.
		/// </param>
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextRepositoryBase(IEntityContext entityContext, ILoggerFactory loggerFactory)
		{
			EntityContext = entityContext;
			Logger = loggerFactory.CreateLogger(GetType());
			// todo|jdevl32: ???
			//Mapper = mapper;
		}

#endregion

#region Implementation of IEntityContextRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<bool> SaveChangesAsync() => await EntityContext.SaveChangesAsync() > 0;

#endregion

	}

}
