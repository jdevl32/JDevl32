﻿using AutoMapper;
using JDevl32.Entity;
using JDevl32.Entity.Generic;
using JDevl32.Logging.Extension;
using JDevl32.Logging.Interface;
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
	/// A (generic) unique entity item context repository (base class).
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <typeparam name="TEntityContext">
	/// The type of the entity context.
	/// </typeparam>
	/// <typeparam name="TUniqueEntity">
	/// The type of the unique entity item.
	/// </typeparam>
	/// <typeparam name="TUniqueValue">
	/// The (value) type of the unique entity item.
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add the type of the unique entity item.
	/// </remarks>
	public abstract class InformableUniqueEntityContextRepositoryBase<TDerivedClass, TEntityContext, TUniqueEntity, TUniqueValue>
		:
		EntityContextRepositoryBase<TDerivedClass, TEntityContext>
		,
		IInformableUniqueEntityContextRepository<TEntityContext, TUniqueEntity, TUniqueValue>
		where
			TDerivedClass
			:
			class
		where
			TEntityContext
			:
			EntityContextBase
		where
			TUniqueEntity
			:
			UniqueEntityBase<TUniqueValue>
		where
			TUniqueValue
			:
			struct
	{

#region Property

#region Implementation of IEntityContextRepository

		//// todo|jdevl32: ??? is the setter needed ???
		///// <inheritdoc />
		///// <remarks>
		///// Last modification:
		///// </remarks>
		//IEntityContext IEntityContextRepository.EntityContext => Mapper.Map<IEntityContext>(EntityContext);

#endregion

		// todo|jdevl32: cleanup...
		/**
#region Implementation of IInformable<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string IInformable<TDerivedClass>.DisplayName => DisplayName;

#endregion
		/**/

#region Implementation of IInformableUniqueEntityContextRepository<out TDerivedClass>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public string DisplayName{ get; set; }

#endregion

#region Implementation of ILoggable

		// todo|jdevl32: ???
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ILogger ILoggable.Logger => Logger;

#endregion

#region Implementation of IUniqueEntityRepository<TUniqueEntity, TUniqueValue>

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		public DbSet<TUniqueEntity> UniqueEntityDbSet { get; }

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
		/// <param name="uniqueEntityDbSet">
		/// A db-set of (all) the unique entity item(s).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected InformableUniqueEntityContextRepositoryBase(TEntityContext entityContext, ILogger<TDerivedClass> logger, IMapper mapper, DbSet<TUniqueEntity> uniqueEntityDbSet)
			:
			base(entityContext, logger, mapper)
		{
			// todo|jdevl32: ???
			//GetUniqueItemMethod = getUniqueItemMethod;
			UniqueEntityDbSet = uniqueEntityDbSet;
		}

#endregion

#region Implementation of IInformableUniqueEntityContextRepository<TDerivedClass>

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		public IEnumerable<TUniqueEntity> Get()
			=>
			Do(this.GetInfo(nameof(Get), "from", "entity context"), "retrieving");

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Remove()
			=>
			Do(this.GetInfo(nameof(Remove), "from", "entity context"), "removing", UniqueEntityDbSet.RemoveRange);

		// todo|jdevl32: constant(s)...
		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		public void Remove(TUniqueEntity uniqueEntity)
			=>
			Do(this.GetInfo(nameof(Remove), "from", "entity context", uniqueEntity), "removing", UniqueEntityDbSet.Remove, uniqueEntity);

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		public void Update(TUniqueEntity uniqueEntity)
		{
			// todo|jdevl32: constant(s)...
			var getInfo =
				new Func<string>
					(
						() =>
						$"the entity context with the {DisplayName} ({uniqueEntity})"
					)
			;

			Do(this.GetInfo(nameof(Update), getInfo), "updating", UniqueEntityDbSet.Update, uniqueEntity);
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
		/// Add the type of the unique entity item.
		/// </remarks>
		protected virtual IEnumerable<TUniqueEntity> Do(string info, string action)
			=>
			Do(info, action, UniqueEntityDbSet.ToList);

		/// <summary>
		/// Invoke a(n action) method, logging possible error information.
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A(n action) method to invoke.
		/// </param>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the (action) method to invoke.
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected virtual void Do(string info, string action, Action<IEnumerable<TUniqueEntity>> method)
			=>
			Do(info, action, method, UniqueEntityDbSet.ToList);

		/// <summary>
		/// Invoke a(n action) method, logging possible error information.
		/// </summary>
		/// <param name="info">
		/// (Logging) information.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A(n action) method to invoke.
		/// </param>
		/// <param name="uniqueEntityMethod">
		/// A method to get (all) the unique entity item(s).
		/// </param>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the (action) method to invoke.
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected virtual void Do(string info, string action, Action<IEnumerable<TUniqueEntity>> method, Func<IEnumerable<TUniqueEntity>> uniqueEntityMethod)
		{
			try
			{
				method(uniqueEntityMethod());
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
		/// Add the type of the unique entity item.
		/// </remarks>
		protected virtual IEnumerable<TUniqueEntity> Do(string info, string action, Func<IEnumerable<TUniqueEntity>> method)
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
		/// <param name="uniqueEntity">
		/// The unique entity item argument of the method to invoke.
		/// </param>
		/// <returns>
		/// The value (of the method invocation).
		/// </returns>
		/// <remarks>
		/// This method re-throws any (and all) exception(s) caught during the try of the method to invoke.
		/// Last modification:
		/// Add the type of the unique entity item.
		/// </remarks>
		protected virtual EntityEntry<TUniqueEntity> Do(string info, string action, Func<TUniqueEntity, EntityEntry<TUniqueEntity>> method, TUniqueEntity uniqueEntity)
		{
			try
			{
				return method(uniqueEntity);
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error {action}{info}:  {ex}");
				throw;
			} // catch
		}

	}

}
