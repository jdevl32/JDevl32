using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JDevl32.Entity.Test.Unit.Common
{

	/// <summary>
	/// A test class.
	/// </summary>
	/// <remarks>
	/// This class should be used to test string representation extension(s).
	/// Last modification:
	/// </remarks>
	[TestClass]
	public class ToPropertyString
	{

		/// <summary>
		/// A test method.
		/// </summary>
		/// <remarks>
		/// This method should be used to test string representation extension(s) for a(n implementation) object.
		/// Last modification:
		/// Refactor ...
		/// </remarks>
		[TestMethod]
		public void Test1()
		{
			var test1 = new Implementation.Test1();
			const string propertySeparator = Entity.Common.DefaultPropertySeparator;
			const string valueSeparator = Entity.Common.DefaultValueSeparator;
			const string test1PublicStringProperty001Name = nameof(test1.PublicStringProperty001);
			var expected = $"{nameof(test1.PublicIntProperty001)}{valueSeparator}{test1.PublicIntProperty001}{propertySeparator}{test1PublicStringProperty001Name}{valueSeparator}{test1PublicStringProperty001Name}";
			var actual = Entity.Common.ToPropertyString(test1, propertySeparator, valueSeparator);

			Assert.AreEqual(expected, actual);
		}

	}

}
