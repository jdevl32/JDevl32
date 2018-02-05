using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JDevl32.Entity
{

	/// <summary>
	/// A common (utility) class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Enhance string representation extension(s).
	/// </remarks>
	public static class Common
	{

#region Constant

		/// <summary>
		/// The default enclosure (string).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public const string DefaultEnclosure = "[]";

		/// <summary>
		/// The default object separator.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public const string DefaultObjectSeparator = "+";

		/// <summary>
		/// The default (object) property value separator.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public const string DefaultPropertySeparator = "|";

		/// <summary>
		/// The default (property) value separator.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public const string DefaultValueSeparator = "=";

		private const BindingFlags DefaultBindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.Instance;

#endregion

		// todo|jdevl32: create extension method (class(e))(s) for object.to-enclosed and .to-property...

#region ToEnclosedString(...)

		/// <summary>
		/// Get a(n enclosed) string representation.
		/// </summary>
		/// <param name="obj">
		/// An object to enclose.
		/// </param>
		/// <returns>
		/// A(n enclosed) string representation.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor the (redundant) object type.
		/// </remarks>
		public static string ToEnclosedString(object obj)
			=>
			ToEnclosedString(obj, DefaultEnclosure);

		/// <summary>
		/// Get a(n enclosed) string representation.
		/// </summary>
		/// <param name="obj">
		/// An object to enclose.
		/// </param>
		/// <param name="enclosure">
		/// The enclosure (string).
		/// </param>
		/// <returns>
		/// A(n enclosed) string representation.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor the (redundant) object type.
		/// </remarks>
		public static string ToEnclosedString(object obj, string enclosure)
			=>
			2 == enclosure.Length ? $"{enclosure[0]}{obj}{enclosure[1]}" : $"{enclosure}{obj}{enclosure}";

		/// <summary>
		/// Get a string representation of (an) enumerable object(s).
		/// </summary>
		/// <param name="obj">
		/// (An) enumerable object(s).
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <param name="objectSeparator">
		/// An object separator.
		/// </param>
		/// <returns>
		/// A string representation of (an) enumerable object(s).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor the property info array (of the object(s)).
		/// </remarks>
		public static string ToEnclosedString(IEnumerable<object> obj, string enclosure, string objectSeparator)
			=>
			ToEnclosedString(obj.Join(objectSeparator), enclosure);

#endregion

#region ToPropertyString(object obj...)

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj)
			=>
			ToPropertyString(obj, DefaultPropertySeparator);

#region ToPropertyString(object obj, BindingFlags bindingFlags...)

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, BindingFlags bindingFlags)
			=>
			ToPropertyString(obj, bindingFlags, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, BindingFlags bindingFlags, string propertySeparator)
			=>
			ToPropertyString(obj, bindingFlags, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, BindingFlags bindingFlags, string propertySeparator, string valueSeparator)
			=>
			ToPropertyString(obj, obj.GetType().GetProperties(bindingFlags), propertySeparator, valueSeparator);

#endregion

#region ToPropertyString(object obj, IEnumerable<PropertyInfo> propertyInfo...)

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertyInfo">
		/// The property info(s) of the object.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, IEnumerable<PropertyInfo> propertyInfo)
			=>
			ToPropertyString(obj, propertyInfo, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertyInfo">
		/// The property info(s) of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, IEnumerable<PropertyInfo> propertyInfo, string propertySeparator)
			=>
			ToPropertyString(obj, propertyInfo, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertyInfo">
		/// The property info(s) of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, IEnumerable<PropertyInfo> propertyInfo, string propertySeparator, string valueSeparator)
			=>
			string.Join
				(
					propertySeparator
					,
					propertyInfo
						.Select
							(
								info
								=>
								ToString(obj, info, valueSeparator)
							)
						.ToArray()
				)
		;

#endregion

#region ToPropertyString(object obj, string propertySeparator...)

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, string propertySeparator)
			=>
			ToPropertyString(obj, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of (the propert(y/ies) of) an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of (the propert(y/ies) of) an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToPropertyString(object obj, string propertySeparator, string valueSeparator)
			=>
			ToPropertyString(obj, obj.GetType().GetProperties(), propertySeparator, valueSeparator);

#endregion

#endregion

#region ToString(...)

#region ToString(object obj...)

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj)
			=>
			ToString(obj, DefaultPropertySeparator);

#region ToString(object obj, BindingFlags bindingFlags...)

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags)
			=>
			ToString(obj, bindingFlags, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, string propertySeparator)
			=>
			ToString(obj, bindingFlags, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, string propertySeparator, string valueSeparator)
			=>
			ToString(obj, bindingFlags, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, string propertySeparator, string valueSeparator, string enclosure)
			=>
			ToString(obj, bindingFlags, obj.GetType(), propertySeparator, valueSeparator, enclosure);

#region ToString(object obj, BindingFlags bindingFlags, Type type...)

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, Type type)
			=>
			ToString(obj, bindingFlags, type, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, Type type, string propertySeparator)
			=>
			ToString(obj, bindingFlags, type, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, Type type, string propertySeparator, string valueSeparator)
			=>
			ToString(obj, bindingFlags, type, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="bindingFlags">
		/// 
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, BindingFlags bindingFlags, Type type, string propertySeparator, string valueSeparator, string enclosure)
			=>
			// todo|jdevl32: refactor (see below) ???
			ToEnclosedString
				(
					$"{type}:{ToPropertyString(obj, bindingFlags, propertySeparator, valueSeparator)}"
					,
					enclosure
				)
		;

#endregion

#endregion

#region ToString(object obj, PropertyInfo propertyInfo...)

		/// <summary>
		/// Get a string representation of an object property (and value).
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertyInfo">
		/// The (object) property info.
		/// </param>
		/// <returns>
		/// A string representation of an object property (and value).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj, PropertyInfo propertyInfo)
			=>
			ToString(obj, propertyInfo, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object property (and value).
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertyInfo">
		/// The (object) property info.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of an object property (and value).
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj, PropertyInfo propertyInfo, string valueSeparator)
			=>
			$"{propertyInfo.Name}{valueSeparator}{propertyInfo.GetValue(obj)}";

#endregion

#region ToString(object obj, string propertySeparator...)

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, string propertySeparator)
			=>
			ToString(obj, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, string propertySeparator, string valueSeparator)
			=>
			ToString(obj, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, string propertySeparator, string valueSeparator, string enclosure)
			=>
			ToString(obj, obj.GetType(), propertySeparator, valueSeparator, enclosure);

#endregion

#region ToString(object obj, Type type...)

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, Type type)
			=>
			ToString(obj, type, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, Type type, string propertySeparator)
			=>
			ToString(obj, type, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, Type type, string propertySeparator, string valueSeparator)
			=>
			ToString(obj, type, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <param name="type">
		/// The type of the object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj, Type type, string propertySeparator, string valueSeparator, string enclosure)
			=>
			// todo|jdevl32: refactor (see above) ???
			ToEnclosedString
				(
					$"{type}:{ToPropertyString(obj, propertySeparator, valueSeparator)}"
					,
					enclosure
				)
		;

#endregion

#endregion

		// todo|jdevl32: !!! revisit these (may need to revert to actual types (per original intent)) !!!
		/**
#region ToString(object obj1, object obj2...)

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		/// The first object.
		/// </param>
		/// <param name="obj2">
		/// The second object.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, object obj2)
			=>
			ToString(obj1, obj2, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		/// The first object.
		/// </param>
		/// <param name="obj2">
		/// The second object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, object obj2, string propertySeparator)
			=>
			ToString(obj1, obj2, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		/// The first object.
		/// </param>
		/// <param name="obj2">
		/// The second object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, object obj2, string propertySeparator, string valueSeparator)
			=>
			ToString(obj1, obj2, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		/// The first object.
		/// </param>
		/// <param name="obj2">
		/// The second object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, object obj2, string propertySeparator, string valueSeparator, string enclosure)
			=>
			ToString(obj1, obj2, propertySeparator, valueSeparator, enclosure, DefaultObjectSeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		/// The first object.
		/// </param>
		/// <param name="obj2">
		/// The second object.
		/// </param>
		/// <param name="propertySeparator">
		/// A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		/// A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		/// An enclosure (string).
		/// </param>
		/// <param name="objectSeparator">
		/// An object separator.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor the property info array (of the object(s)).
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, object obj2, string propertySeparator, string valueSeparator, string enclosure, string objectSeparator)
		{
			var value = new[]
			{
				// todo|jdevl32: replace default (.get-properties())...
				//ToString(obj1, obj1.GetType().GetProperties(), propertySeparator, valueSeparator, enclosure)
				ToString(obj1, propertySeparator, valueSeparator, enclosure)
				,
				// todo|jdevl32: replace default (.get-properties())...
				//ToString(obj2, obj2.GetType().GetProperties(), propertySeparator, valueSeparator, enclosure)
				ToString(obj2, propertySeparator, valueSeparator, enclosure)
			}
			;
			return ToEnclosedString(value, enclosure, objectSeparator);
		}

		// todo|jdevl32: re-sort (move up)...

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		///     The first object.
		/// </param>
		/// <param name="bindingFlag1"></param>
		/// <param name="obj2">
		///     The second object.
		/// </param>
		/// <param name="propertySeparator">
		///     A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		///     A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		///     An enclosure (string).
		/// </param>
		/// <param name="objectSeparator">
		///     An object separator.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString(object obj1, BindingFlags bindingFlag1, object obj2, string propertySeparator, string valueSeparator, string enclosure, string objectSeparator)
		{
			var value = new[]
			{
				ToString(obj1, bindingFlag1, propertySeparator, valueSeparator, enclosure)
				,
				ToString(obj2, propertySeparator, valueSeparator, enclosure)
			}
			;
			return ToEnclosedString(value, enclosure, objectSeparator);
		}

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <param name="obj1">
		///     The first object.
		/// </param>
		/// <param name="bindingFlag1"></param>
		/// <param name="obj2">
		///     The second object.
		/// </param>
		/// <param name="bindingFlag2"></param>
		/// <param name="propertySeparator">
		///     A(n object) property separator.
		/// </param>
		/// <param name="valueSeparator">
		///     A (property) value separator.
		/// </param>
		/// <param name="enclosure">
		///     An enclosure (string).
		/// </param>
		/// <param name="objectSeparator">
		///     An object separator.
		/// </param>
		/// <returns>
		/// A string representation of a pair of objects.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Refactor the property info array (of the object(s)).
		/// Refactor (redundant) object type.
		/// </remarks>
		public static string ToString(object obj1, BindingFlags bindingFlag1, object obj2, BindingFlags bindingFlag2, string propertySeparator, string valueSeparator, string enclosure, string objectSeparator)
		{
			var value = new[]
			{
				//ToString(obj1, obj1.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance), propertySeparator, valueSeparator, enclosure)
				ToString(obj1, bindingFlag1, propertySeparator, valueSeparator, enclosure)
				,
				// todo|jdevl32: replace default (.get-properties())...
				//ToString(obj2, obj2.GetType().GetProperties(), propertySeparator, valueSeparator, enclosure)
				ToString(obj2, bindingFlag2, propertySeparator, valueSeparator, enclosure)
			}
			;
			return ToEnclosedString(value, enclosure, objectSeparator);
		}

#endregion
		/**/

#endregion

	}

}
