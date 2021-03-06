﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JDevl32.Entity.Test.Unit.Common
{

	/// <summary>
	/// A test class.
	/// </summary>
	/// <remarks>
	/// This class should be used to test string representation extension(s).
	/// Last modification:
	/// (Re-)implement due to:
	/// Refactor unique entity item(s) on (value) type of (global) unique identifier.
	/// </remarks>
	[TestClass]
	public class ToString
	{

		/// <summary>
		/// A test method.
		/// </summary>
		/// <remarks>
		/// This method should be used to test string representation extension(s) for a(n implementation) object.
		/// Last modification:
		/// Enhance string representation (include type name).
		/// </remarks>
		[TestMethod]
		public void Test1()
		{
			var test1 = new Implementation.Test1();
			const string propertySeparator = Entity.Common.DefaultPropertySeparator;
			const string valueSeparator = Entity.Common.DefaultValueSeparator;
			const string enclosure = Entity.Common.DefaultEnclosure;
			var expected = Entity.Common.ToEnclosedString($"{test1.GetType()}:{Entity.Common.ToPropertyString(test1, propertySeparator, valueSeparator)}", enclosure);
			var actual = Entity.Common.ToString(test1, propertySeparator, valueSeparator, enclosure);

			Assert.AreEqual(expected, actual);
		}

	}

}
