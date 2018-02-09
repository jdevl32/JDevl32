﻿using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JDevl32.Entity
{

	/// <summary>
	/// An informable entity context sower (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement (as interface).
	/// </remarks>
	public abstract class InformableEntityContextSowerBase
		:
		EntityContextSowerBase
		,
		IInformableEntityContextSower
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
		protected InformableEntityContextSowerBase(IEntityContext entityContext, ILoggerFactory loggerFactory)
			:
			base(entityContext, loggerFactory)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Create an informable entity context sower.
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
		protected InformableEntityContextSowerBase(IEntityContext entityContext, ILoggerFactory loggerFactory, string displayName)
			:
			this(entityContext, loggerFactory)
			=>
			DisplayName = displayName;

#endregion

#region Implementation of IInformableEntityContextSower

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<bool> TrySeed()
		{
			try
			{
				await Seed();
				return true;
			} // try
			catch (Exception exception)
			{
				Logger.LogError(exception, $"Error on seed {DisplayName}:  {exception}");
			} // catch

			return false;
		}

#endregion

	}

}
