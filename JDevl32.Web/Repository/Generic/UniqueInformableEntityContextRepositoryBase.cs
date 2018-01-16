using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Logging.Interface.Generic;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JDevl32.Web.Repository.Generic
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
	/// Remove unique item controller.
	/// </remarks>
	public abstract class UniqueInformableEntityContextRepositoryBase<TDerivedClass, TEntityContext>
		:
		EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		,
		IUniqueInformableEntityContextRepository<TDerivedClass>
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

#region IInformable<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// (Re-)implement explicitly.
		/// </remarks>
		string IInformable<TDerivedClass>.DisplayName => DisplayName;

#endregion

#region IUniqueInformableEntityContextRepository<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add setter.
		/// </remarks>
		public string DisplayName{ get; set; }

#endregion

#region IUniqueRepository

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Replace method to get a db-set of (all) the unique item entity items(s) with property.
		/// </remarks>
		public DbSet<UniqueBase> UniqueDbSet { get; }

#endregion

		// todo|jdevl32: ???
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
		/// <param name="uniqueDbSet">
		/// The db-set of unique item entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Replace method to get a db-set of (all) the unique item entity items(s) with property.
		/// </remarks>
		protected UniqueInformableEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<UniqueBase> uniqueDbSet)
			:
			base(entityContext, logger, mapper)
		{
			UniqueDbSet = uniqueDbSet;
		}

#endregion

#region IUniqueInformableEntityContextRepository<TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor display name to informable (interface).
		/// </remarks>
		public IEnumerable<IUnique> Get()
		{
			var introAction = nameof(Get);
			var errorAction = "retrieving";
			var info = string.Empty;

			try
			{
				info = $" (all) the {DisplayName}(s) from the entity context";
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, string.Empty);
			} // catch

			Logger.LogInformation($"{introAction}{info}...");

			try
			{
				return Mapper.Map<IEnumerable<IUnique>>(UniqueDbSet.ToList());
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {errorAction}{info}:  {ex}");
				throw;
			} // catch
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor display name to informable (interface).
		/// </remarks>
		public void Remove()
		{
			var introAction = nameof(Remove);
			var errorAction = "removing";
			var info = string.Empty;

			try
			{
				info = $" (all) the {DisplayName}(s) from the entity context";
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, string.Empty);
			} // catch

			Logger.LogInformation($"{introAction}{info}...");

			try
			{
				UniqueDbSet.RemoveRange(UniqueDbSet.ToList());
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {errorAction}{info}:  {ex}");
				throw;
			} // catch
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor display name to informable (interface).
		/// </remarks>
		public void Remove(IUnique uniqueItem)
		{
			var introAction = nameof(Remove);
			var errorAction = "removing";
			var info = string.Empty;

			try
			{
				info = $" the {DisplayName} ({uniqueItem}) from the entity context";
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, string.Empty);
			} // catch

			Logger.LogInformation($"{introAction}{info}...");

			try
			{
				UniqueDbSet.Remove(Mapper.Map<UniqueBase>(uniqueItem));
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {errorAction}{info}:  {ex}");
				throw;
			} // catch
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor display name to informable (interface).
		/// </remarks>
		public void Update(IUnique uniqueItem)
		{
			var introAction = nameof(Update);
			var errorAction = "updating";
			var info = string.Empty;

			try
			{
				info = $" the entity context with the {DisplayName} ({uniqueItem})";
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, string.Empty);
			} // catch

			Logger.LogInformation($"{introAction}{info}...");

			try
			{
				UniqueDbSet.Update(Mapper.Map<UniqueBase>(uniqueItem));
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {errorAction}{info}:  {ex}");
				throw;
			} // catch
		}

#endregion

	}

}
