using AutoMapper;
using JDevl32.Entity.Interface;
using JDevl32.Entity.Model;
using JDevl32.Logging.Extension;
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
		/// Add container name.
		/// (Re-)implement extension (class).
		/// </remarks>
		public IEnumerable<IUnique> Get()
		{
			// todo|jdevl32: constant(s)...
			var method =
				new Func<IEnumerable<IUnique>>
					(
						() =>
						Mapper.Map<IEnumerable<IUnique>>(UniqueDbSet.ToList())
					)
			;

			return Do(this.GetInfo(nameof(Get), "from", "entity context"), "retrieving", method);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
		/// </remarks>
		public void Remove()
		{
			// todo|jdevl32: constant(s)...
			var method =
				new Action
					(
						() =>
						UniqueDbSet.RemoveRange(UniqueDbSet.ToList())
					)
			;

			Do(this.GetInfo(nameof(Remove), "from", "entity context"), "removing", method);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
		/// </remarks>
		public void Remove(IUnique uniqueItem)
		{
			// todo|jdevl32: constant(s)...
			var method =
				new Action
					(
						() =>
						UniqueDbSet.Remove(Mapper.Map<UniqueBase>(uniqueItem))
					)
			;

			Do(this.GetInfo(nameof(Remove), "from", "entity context", uniqueItem), "removing", method);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// (Re-)implement extension (class).
		/// </remarks>
		public void Update(IUnique uniqueItem)
		{
			// todo|jdevl32: constant(s)...
			var getInfo =
				new Func<string>
					(
						() =>
						$" the entity context with the {DisplayName} ({uniqueItem})"
					)
			;
			var method =
				new Action
					(
						() =>
						UniqueDbSet.Update(Mapper.Map<UniqueBase>(uniqueItem))
					)
			;

			Do(this.GetInfo(nameof(Update), getInfo), "updating", method);
		}

#endregion

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
		protected virtual void Do(string info, string action, Action method)
		{
			try
			{
				method();
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
		/// </remarks>
		protected virtual IEnumerable<IUnique> Do(string info, string action, Func<IEnumerable<IUnique>> method)
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

	}

}
