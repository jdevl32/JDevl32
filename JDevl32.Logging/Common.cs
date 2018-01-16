using JDevl32.Logging.Interface.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Logging
{

	/// <summary>
	/// A common (helper) class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static class Common
	{

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <typeparam name="TDerivedClass">
		/// This should be the type of the derived class from this base class (for the logger).
		/// </typeparam>
		/// <param name="informable">
		/// An informable object.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="containerName">
		/// A container name.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// </remarks>
		public static string GetInfo<TDerivedClass>(IInformable<TDerivedClass> informable, string action, string direction, string containerName)
			where
				TDerivedClass
				:
				class
			=>
			GetInfo(informable, action, () => GetInfo(informable, direction, containerName));

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <typeparam name="TDerivedClass">
		/// This should be the type of the derived class from this base class (for the logger).
		/// </typeparam>
		/// <param name="informable">
		/// An informable object.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="containerName">
		/// A container name.
		/// </param>
		/// <param name="item">
		/// An item to include in the (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// </remarks>
		public static string GetInfo<TDerivedClass>(IInformable<TDerivedClass> informable, string action, string direction, string containerName, object item)
			where
				TDerivedClass
				:
				class
			=>
			GetInfo(informable, action, () => GetInfo(informable, direction, containerName, item));

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <typeparam name="TDerivedClass">
		/// This should be the type of the derived class from this base class (for the logger).
		/// </typeparam>
		/// <param name="informable">
		/// An informable object.
		/// </param>
		/// <param name="action">
		/// An action to include in the (logging) information.
		/// </param>
		/// <param name="method">
		/// A method to get (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string GetInfo<TDerivedClass>(IInformable<TDerivedClass> informable, string action, Func<string> method)
			where
				TDerivedClass
				:
				class
		{
			informable.Logger.LogInformation(action);

			var info = string.Empty;

			try
			{
				info = method();

				informable.Logger.LogInformation($"...{info}...");
			} // try
			catch (Exception ex)
			{
				informable.Logger.LogError(ex, string.Empty);
			} // catch

			return info;
		}

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <typeparam name="TDerivedClass">
		/// This should be the type of the derived class from this base class (for the logger).
		/// </typeparam>
		/// <param name="informable">
		/// An informable object.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="containerName">
		/// A container name.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// </remarks>
		public static string GetInfo<TDerivedClass>(IInformable<TDerivedClass> informable, string direction, string containerName)
			where
				TDerivedClass
				:
				class
			=>
			$" (all) the {informable.DisplayName}(s) {direction} the {containerName}";

		/// <summary>
		/// Get (logging) information.
		/// </summary>
		/// <typeparam name="TDerivedClass">
		/// This should be the type of the derived class from this base class (for the logger).
		/// </typeparam>
		/// <param name="informable">
		/// An informable object.
		/// </param>
		/// <param name="direction">
		/// The direction that the (logging) information flows.
		/// </param>
		/// <param name="containerName">
		/// A container name.
		/// </param>
		/// <param name="item">
		/// An item to include in the (logging) information.
		/// </param>
		/// <returns>
		/// The (logging) information.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Add container name.
		/// </remarks>
		public static string GetInfo<TDerivedClass>(IInformable<TDerivedClass> informable, string direction, string containerName, object item)
			where
				TDerivedClass
				:
				class
			=>
			$" the {informable.DisplayName} ({item}) {direction} the {containerName}";

	}

}
