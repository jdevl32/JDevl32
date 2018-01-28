using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Logging.Extension;
using JDevl32.Web.Repository.Interface.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
	/// <typeparam name="TUnique">
	/// The unique item type.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Refactor display-name (re-implement setter in base (informable) interface).
	/// </remarks>
	public abstract class UniqueInformableEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUnique>
		:
		EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		,
		IUniqueInformableEntityContextRepository<TDerivedClass, TUnique>
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

		// todo|jdevl32: cleanup...
		/**
#region IInformable<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// (Re-)implement explicitly.
		/// </remarks>
		string IInformable<TDerivedClass>.DisplayName => DisplayName;

#endregion
		/**/

#region IUniqueInformableEntityContextRepository<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Refactor display-name (re-implement setter in base (informable) interface).
		/// </remarks>
		public string DisplayName{ get; set; }

#endregion

#region IUniqueRepository<TUnique>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		public DbSet<TUnique> UniqueDbSet { get; }

#endregion

		// todo|jdevl32: ???
		///// <summary>
		///// The entity context.
		///// </summary>
		///// <remarks>
		///// Last modification:
		///// </remarks>
		//public virtual TEntityContext EntityContext { get; }

		//protected Func<IEnumerable<TUnique>> GetUniqueItemMethod;

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <param name="entityContext">
		/// An entity context.
		/// </param>
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <param name="mapper">
		/// A mapper.
		/// </param>
		/// <param name="uniqueDbSet">
		/// A db-set of unique item entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		protected UniqueInformableEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<TUnique> uniqueDbSet)
			:
			base(entityContext, logger, mapper)
		{
			// todo|jdevl32: ???
			//GetUniqueItemMethod = getUniqueItemMethod;
			UniqueDbSet = uniqueDbSet;
		}

#endregion

#region IUniqueInformableEntityContextRepository<TDerivedClass>

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		public IEnumerable<TUnique> Get()
			=>
			Do(this.GetInfo(nameof(Get), "from", "entity context"), "retrieving");

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		public void Remove()
			=>
			Do(this.GetInfo(nameof(Remove), "from", "entity context"), "removing", UniqueDbSet.RemoveRange);

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		public void Remove(TUnique uniqueItem)
			=>
			Do(this.GetInfo(nameof(Remove), "from", "entity context", uniqueItem), "removing", UniqueDbSet.Remove, uniqueItem);

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Correct whitespace usage.
		/// </remarks>
		public void Update(TUnique uniqueItem)
		{
			// todo|jdevl32: constant(s)...
			var getInfo =
				new Func<string>
					(
						() =>
						$"the entity context with the {DisplayName} ({uniqueItem})"
					)
			;

			Do(this.GetInfo(nameof(Update), getInfo), "updating", UniqueDbSet.Update, uniqueItem);
		}

#endregion

		/// <summary>
		/// Invoke a method, logging possible error information, and return the value (of the method invocation).
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <returns>
		/// The value (of the method invocation).
		/// </returns>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the method to invoke.
		/// Last modification:
		/// </remarks>
		protected virtual IEnumerable<TUnique> Do(string info, string action)
			=>
			Do(info, action, UniqueDbSet.ToList);

		/// <summary>
		/// Invoke a(n) (action) method, logging possible error information.
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A(n) (action) method to invoke.
		/// </param>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the (action) method to invoke.
		/// Last modification:
		/// </remarks>
		protected virtual void Do(string info, string action, Action<IEnumerable<TUnique>> method)
			=>
			Do(info, action, method, UniqueDbSet.ToList);

		/// <summary>
		/// Invoke a(n) (action) method, logging possible error information.
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A(n) (action) method to invoke.
		/// </param>
		/// <param name="uniqueItemMethod">
		/// A method to get (all) the unique item(s).
		/// </param>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the (action) method to invoke.
		/// Last modification:
		/// </remarks>
		protected virtual void Do(string info, string action, Action<IEnumerable<TUnique>> method, Func<IEnumerable<TUnique>> uniqueItemMethod)
		{
			try
			{
				method(uniqueItemMethod());
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
				throw;
			} // catch
		}

		/// <summary>
		/// Invoke a method, logging possible error information, and return the value (of the method invocation).
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A method to invoke.
		/// </param>
		/// <returns>
		/// The value (of the method invocation).
		/// </returns>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the method to invoke.
		/// Last modification:
		/// Add unique item type.
		/// </remarks>
		protected virtual IEnumerable<TUnique> Do(string info, string action, Func<IEnumerable<TUnique>> method)
		{
			try
			{
				return method();
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
				throw;
			} // catch
		}

		/// <summary>
		/// Invoke a method, logging possible error information, and return the value (of the method invocation).
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A method to invoke.
		/// </param>
		/// <param name="uniqueItem">
		/// A unique item argument of the method to invoke.
		/// </param>
		/// <returns>
		/// The value (of the method invocation).
		/// </returns>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the method to invoke.
		/// Last modification:
		/// </remarks>
		protected virtual EntityEntry<TUnique> Do(string info, string action, Func<TUnique, EntityEntry<TUnique>> method, TUnique uniqueItem)
		{
			try
			{
				return method(uniqueItem);
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
				throw;
			} // catch
		}

	}

}
