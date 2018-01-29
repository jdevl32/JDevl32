using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Mapper.Interface;
using JDevl32.Web.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Web.Repository.Generic
{

	/// <summary>
	/// A (generic) entity context repository (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Restrict entity context type parameter to db-context type.
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
			DbContext
			,
			IEntityContext
	{

#region Property

#region Implementation of IEntityContextRepository

		// todo|jdevl32: ??? is the setter needed ???
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// (Re-)implement explicitly.
		/// </remarks>
		IEntityContext IEntityContextRepository.EntityContext => Mapper.Map<IEntityContext>(EntityContext);

#endregion

#region Implementation of ILoggable<TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

#region Implementation of IInstanceMapper

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
		/// An entity context.
		/// </param>
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <param name="mapper">
		/// A mapper.
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

#region Implementation of IEntityContextRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<bool> SaveChangesAsync() => await EntityContext.SaveChangesAsync() > 0;

#endregion

	}

}
