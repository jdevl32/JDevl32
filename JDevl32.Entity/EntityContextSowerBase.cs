using System.Threading.Tasks;
using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;

namespace JDevl32.Entity
{

	/// <summary>
	/// An entity context sower (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextSowerBase
		:
		IEntityContextSower
		,
		ILoggable
		// todo:jdevl32: ???
		/**
		,
		IInstanceMapper
		/**/
	{

#region Property

#region Implementation of IEntityContextSower

		// todo:jdevl32: ???
		/**
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEntityContext IEntityContextSower.EntityContext
		{
			get => Mapper.Map<IEntityContext>(EntityContext);
			// todo|jdevl32: is the setter needed ???
		}
		/**/

		// todo:jdevl32: ??? should this be entity-context-base (abstract base class instead of interface) ???
		/// <inheritdoc />
		/// <summary>
		/// The entity context.
		/// </summary>
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

		// todo:jdevl32: ???
		/**
#region Implementation of IInstanceMapper

		// todo:jdevl32: ???
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
		protected EntityContextSowerBase(IEntityContext entityContext, ILoggerFactory loggerFactory)
		{
			EntityContext = entityContext;
			Logger = loggerFactory.CreateLogger(GetType());
			// todo|jdevl32: ???
			//Mapper = mapper;
		}

#endregion

#region IImplementation of EntityContextSower

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public abstract Task Seed();

#endregion

	}

}
