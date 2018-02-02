using JDevl32.Entity.Interface.Generic;
using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A(n) (generic) entity context sower (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextSowerBase<TEntityContext>
		:
		IEntityContextSower<TEntityContext>
		,
		ILoggable
		// todo|jdevl32: ???
		/**
		,
		IInstanceMapper
		/**/
		where
			TEntityContext
			:
			EntityContextBase
	{

#region Property

#region Implementation of IEntityContextSower<TEntityContext>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual TEntityContext EntityContext { get; }

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
		protected EntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
		{
			EntityContext = entityContext;
			Logger = loggerFactory.CreateLogger(GetType());
			// todo|jdevl32: ???
			//Mapper = mapper;
		}

#endregion

#region IEntityContextSower<TEntityContext>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public abstract Task Seed();

#endregion

	}

}
