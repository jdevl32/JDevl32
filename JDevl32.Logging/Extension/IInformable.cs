using JDevl32.Logging.Interface.Generic;
using System;

namespace JDevl32.Logging.Extension
{

	/// <summary>
	/// An extension to the informable interface.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Implement (non-generic) get (logging) information.
	/// </remarks>
	public static class IInformable
	{

		/// <summary>
		/// Get (logging) information.
		/// </summary>
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
		/// </remarks>
		public static string GetInfo(this Interface.IInformable informable, string action, string direction, string containerName)
			=>
			Common.GetInfo(informable, action, direction, containerName);

		/// <summary>
		/// Get (logging) information.
		/// </summary>
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
		/// </remarks>
		public static string GetInfo(this Interface.IInformable informable, string action, string direction, string containerName, object item)
			=>
			Common.GetInfo(informable, action, direction, containerName, item);

		/// <summary>
		/// Get (logging) information.
		/// </summary>
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
		public static string GetInfo(this Interface.IInformable informable, string action, Func<string> method)
			=>
			Common.GetInfo(informable, action, method);

		/// <summary>
		/// Get (logging) information.
		/// </summary>
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
		/// </remarks>
		public static string GetInfo(this Interface.IInformable informable, string direction, string containerName)
			=>
			Common.GetInfo(informable, direction, containerName);

		/// <summary>
		/// Get (logging) information.
		/// </summary>
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
		/// </remarks>
		public static string GetInfo(Interface.IInformable informable, string direction, string containerName, object item)
			=>
			Common.GetInfo(informable, direction, containerName, item);

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
		public static string GetInfo<TDerivedClass>(this IInformable<TDerivedClass> informable, string action, string direction, string containerName)
			where
				TDerivedClass
				:
				class
			=>
			Common.GetInfo(informable, action, direction, containerName);

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
		public static string GetInfo<TDerivedClass>(this IInformable<TDerivedClass> informable, string action, string direction, string containerName, object item)
			where
				TDerivedClass
				:
				class
			=>
			Common.GetInfo(informable, action, direction, containerName, item);

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
		public static string GetInfo<TDerivedClass>(this IInformable<TDerivedClass> informable, string action, Func<string> method)
			where
				TDerivedClass
				:
				class
			=>
			Common.GetInfo(informable, action, method);

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
		public static string GetInfo<TDerivedClass>(this IInformable<TDerivedClass> informable, string direction, string containerName)
			where
				TDerivedClass
				:
				class
			=>
			Common.GetInfo(informable, direction, containerName);

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
			Common.GetInfo(informable, direction, containerName, item);

	}

}
