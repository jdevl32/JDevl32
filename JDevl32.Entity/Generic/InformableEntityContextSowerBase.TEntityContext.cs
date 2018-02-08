using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A(n) (generic) informable entity context sower (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class InformableEntityContextSowerBase<TEntityContext>
		:
		EntityContextSowerBase<TEntityContext>
		,
		IInformable
		where
			TEntityContext
			:
			EntityContextBase
	{

#region Property

#region Implementation of IInformable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string IInformable.DisplayName
		{
			get => DisplayName;
			set => throw new NotImplementedException();
		}

#endregion

		/// <summary>
		/// The display name.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string DisplayName { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory)
			:
			base(entityContext, loggerFactory)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a(n) (generic) informable entity context sower.
		/// </summary>
		/// <param name="entityContext">
		/// An entity context.
		/// </param>
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <param name="displayName">
		/// A display name.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected InformableEntityContextSowerBase(TEntityContext entityContext, ILoggerFactory loggerFactory, string displayName)
			:
			this(entityContext, loggerFactory)
			=>
			DisplayName = displayName;

#endregion

	}

}
