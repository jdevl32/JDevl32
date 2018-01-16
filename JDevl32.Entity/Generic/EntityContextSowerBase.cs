using System.Threading.Tasks;
using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Mapper.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A (generic) entity context sower (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextSowerBase<TDerivedClass, TEntityContext>
		:
		IEntityContextSower
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

#region IEntityContextSower

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEntityContext IEntityContextSower.EntityContext
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
		protected EntityContextSowerBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper)
		{
			EntityContext = entityContext;
			Logger = logger;
			Mapper = mapper;
		}

#endregion

#region IEntityContextSower

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public abstract Task Seed();

#endregion

	}

}
