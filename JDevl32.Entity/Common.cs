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

#endregion

		/// <summary>
		/// Get a(n enclosed) string representation.
		/// </summary>
		/// <param name="value">
		/// A (string) value to enclose.
		/// </param>
		/// <returns>
		/// A(n enclosed) string representation.
		/// </returns>
		public static string ToEnclosedString(string value)
			=>
			ToEnclosedString(value, DefaultEnclosure);

		/// <summary>
		/// Get a(n enclosed) string representation.
		/// </summary>
		/// <param name="value">
		/// A (string) value to enclose.
		/// </param>
		/// <param name="enclosure">
		/// The enclosure (string).
		/// </param>
		/// <returns>
		/// A(n enclosed) string representation.
		/// </returns>
		public static string ToEnclosedString(string value, string enclosure)
			=>
			2 == enclosure.Length ? $"{enclosure[0]}{value}{enclosure[1]}" : $"{enclosure}{value}{enclosure}";

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
		/// <param name="obj">
		/// An object.
		/// </param>
		/// <returns>
		/// A string representation of an object.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static string ToString<T>(T obj)
			=>
			ToString(obj, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
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
		public static string ToString<T>(T obj, string propertySeparator)
			=>
			ToString(obj, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
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
		public static string ToString<T>(T obj, string propertySeparator, string valueSeparator)
			=>
			ToString(obj, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of an object.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
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
		public static string ToString<T>(T obj, string propertySeparator, string valueSeparator, string enclosure)
			=>
			ToEnclosedString
				(
					string.Join
						(
							propertySeparator
							,
							typeof(T)
								.GetProperties()
								.Select
									(
										propertyInfo
										=>
										ToString(obj, propertyInfo, valueSeparator)
									)
								.ToArray()
						)
					,
					enclosure
				)
			;

		/// <summary>
		/// Get a string representation of an object property (and value).
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
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
		/// </remarks>
		private static string ToString<T>(T obj, PropertyInfo propertyInfo)
			=>
			ToString(obj, propertyInfo, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of an object property (and value).
		/// </summary>
		/// <typeparam name="T">
		/// The type of the object.
		/// </typeparam>
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
		/// </remarks>
		private static string ToString<T>(T obj, PropertyInfo propertyInfo, string valueSeparator)
			=>
			$"{propertyInfo.Name}{valueSeparator}{propertyInfo.GetValue(obj)}";

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <typeparam name="T1">
		/// The type of the first object.
		/// </typeparam>
		/// <typeparam name="T2">
		/// The type of the second object.
		/// </typeparam>
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
		/// </remarks>
		public static string ToString<T1, T2>(T1 obj1, T2 obj2)
			=>
			ToString(obj1, obj2, DefaultPropertySeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <typeparam name="T1">
		/// The type of the first object.
		/// </typeparam>
		/// <typeparam name="T2">
		/// The type of the second object.
		/// </typeparam>
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
		/// </remarks>
		public static string ToString<T1, T2>(T1 obj1, T2 obj2, string propertySeparator)
			=>
			ToString(obj1, obj2, propertySeparator, DefaultValueSeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <typeparam name="T1">
		/// The type of the first object.
		/// </typeparam>
		/// <typeparam name="T2">
		/// The type of the second object.
		/// </typeparam>
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
		/// </remarks>
		public static string ToString<T1, T2>(T1 obj1, T2 obj2, string propertySeparator, string valueSeparator)
			=>
			ToString(obj1, obj2, propertySeparator, valueSeparator, DefaultEnclosure);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <typeparam name="T1">
		/// The type of the first object.
		/// </typeparam>
		/// <typeparam name="T2">
		/// The type of the second object.
		/// </typeparam>
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
		/// </remarks>
		public static string ToString<T1, T2>(T1 obj1, T2 obj2, string propertySeparator, string valueSeparator, string enclosure)
			=>
			ToString(obj1, obj2, propertySeparator, valueSeparator, enclosure, DefaultObjectSeparator);

		/// <summary>
		/// Get a string representation of a pair of objects.
		/// </summary>
		/// <typeparam name="T1">
		/// The type of the first object.
		/// </typeparam>
		/// <typeparam name="T2">
		/// The type of the second object.
		/// </typeparam>
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
		/// </remarks>
		public static string ToString<T1, T2>(T1 obj1, T2 obj2, string propertySeparator, string valueSeparator, string enclosure, string objectSeparator)
			=>
			ToEnclosedString($"{ToString(obj1, propertySeparator, valueSeparator, enclosure)}{objectSeparator}{ToString(obj2, propertySeparator, valueSeparator, enclosure)}", enclosure);

	}

}
