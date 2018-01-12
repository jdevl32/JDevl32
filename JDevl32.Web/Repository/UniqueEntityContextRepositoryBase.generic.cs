using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Web.Controller.Interface;
using JDevl32.Web.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JDevl32.Web.Repository
{

	/// <summary>
	/// A (generic) unique item entity context repository (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TEntityContext">
	/// The entity context type.
	/// </typeparam>
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The unique item entity type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class UniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUnique, TUniqueEntity>
		:
		EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		,
		IUniqueEntityContextRepository<TUnique, TUniqueEntity>
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
		where
			TUnique
			:
			IUnique
		where
			TUniqueEntity
			:
			UniqueBase
	{

#region Property

#region IEntityContextRepository

		//// todo|jdevl32: ??? is the setter needed ???
		///// <inheritdoc />
		///// <remarks>
		///// Last modification:
		///// Re-implement explicitly.
		///// </remarks>
		//IEntityContext IEntityContextRepository.EntityContext => Mapper.Map<IEntityContext>(EntityContext);

#endregion

#region ILoggable<TDerivedClass>

#endregion

#region IInstanceMapper

#endregion

#region IUniqueRepository<TUnique, TUniqueEntity>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Func<DbSet<TUniqueEntity>> GetUniqueEntityDbSet { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IUniqueController<TUnique> UniqueController { get; set; }

		#endregion

		///// <summary>
		///// The entity context.
		///// </summary>
		///// <remarks>
		///// Last modification:
		///// </remarks>
		//public virtual TEntityContext EntityContext { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <param name="entityContext">
		/// The entity context.
		/// </param>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <param name="getUniqueEntityDbSet">
		/// The method to get the db-set of unique item entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add the method to get the db-set of all (the) unique item entity item(s) as an argument.
		/// </remarks>
		protected UniqueEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, Func<DbSet<TUniqueEntity>> getUniqueEntityDbSet)
			:
			base(entityContext, logger, mapper)
		{
			GetUniqueEntityDbSet = getUniqueEntityDbSet;
		}

#endregion

#region IEntityContextRepository

#endregion

#region IUniqueRepository<TUnique, TUniqueEntity>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IEnumerable<TUnique> Get()
		{
			Logger.LogInformation($"Get (all) the {UniqueController.DisplayName}(s) from the entity context...");

			return Mapper.Map<IEnumerable<TUnique>>(GetUniqueEntityDbSet().ToList());
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Remove()
		{
			Logger.LogInformation($"Remove (all) the {UniqueController.DisplayName}(s) from the entity context...");

			GetUniqueEntityDbSet().RemoveRange(GetUniqueEntityDbSet().ToList());
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Remove(TUnique uniqueItem)
		{
			Logger.LogInformation($"Remove the {UniqueController.DisplayName} ({uniqueItem}) from the entity context...");

			GetUniqueEntityDbSet().Remove(Mapper.Map<TUniqueEntity>(uniqueItem));
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Update(TUnique uniqueItem)
		{
			Logger.LogInformation($"Update the entity context with the {UniqueController.DisplayName} ({uniqueItem})...");

			GetUniqueEntityDbSet().Update(Mapper.Map<TUniqueEntity>(uniqueItem));
		}

#endregion

	}

}
