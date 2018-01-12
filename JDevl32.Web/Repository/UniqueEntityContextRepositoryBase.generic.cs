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
	/// <remarks>
	/// Last modification:
	/// Remove unique item (and entity) type(s).
	/// </remarks>
	public abstract class UniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext>
		:
		EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		,
		IUniqueEntityContextRepository
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

#region IEntityContextRepository

		//// todo|jdevl32: ??? is the setter needed ???
		///// <inheritdoc />
		///// <remarks>
		///// Last modification:
		///// Re-implement explicitly.
		///// </remarks>
		//IEntityContext IEntityContextRepository.EntityContext => Mapper.Map<IEntityContext>(EntityContext);

#endregion

#region IUniqueRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Func<DbSet<UniqueBase>> GetUniqueEntityDbSet { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IUniqueController UniqueController { get; set; }

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
		/// Remove unique item (and entity) type(s).
		/// </remarks>
		protected UniqueEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, Func<DbSet<UniqueBase>> getUniqueEntityDbSet)
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
		public IEnumerable<IUnique> Get()
		{
			Logger.LogInformation($"Get (all) the {UniqueController.DisplayName}(s) from the entity context...");

			return Mapper.Map<IEnumerable<IUnique>>(GetUniqueEntityDbSet().ToList());
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
		public void Remove(IUnique uniqueItem)
		{
			Logger.LogInformation($"Remove the {UniqueController.DisplayName} ({uniqueItem}) from the entity context...");

			GetUniqueEntityDbSet().Remove(Mapper.Map<UniqueBase>(uniqueItem));
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Update(IUnique uniqueItem)
		{
			Logger.LogInformation($"Update the entity context with the {UniqueController.DisplayName} ({uniqueItem})...");

			GetUniqueEntityDbSet().Update(Mapper.Map<UniqueBase>(uniqueItem));
		}

#endregion

	}

}
