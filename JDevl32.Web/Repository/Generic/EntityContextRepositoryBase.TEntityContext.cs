using JDevl32.Entity;
using JDevl32.Logging.Interface;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Generic
{

	/// <summary>
	/// A(n) (generic) entity context repository (base class).
	/// </summary>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextRepositoryBase<TEntityContext>
		:
		IEntityContextRepository<TEntityContext>
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

#region Implementation of IEntityContextRepository<TEntityContext>

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
		protected EntityContextRepositoryBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
		{
			EntityContext = entityContext;
			Logger = loggerFactory.CreateLogger(GetType());
			// todo|jdevl32: ???
			//Mapper = mapper;
		}

#endregion

#region Implementation of IEntityContextRepository<TEntityContext>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<bool> SaveChangesAsync() => await EntityContext.SaveChangesAsync() > 0;

#endregion

	}

}
