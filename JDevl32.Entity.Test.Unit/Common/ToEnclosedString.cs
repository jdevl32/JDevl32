using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JDevl32.Entity.Test.Unit.Common
{

	[TestClass]
	public class ToEnclosedString
	{

		[TestMethod]
		public void EnclosureLength0()
		{
			var enclosure = string.Empty;
			const string value = "a";
			const string expect = "a";
			var actual = Entity.Common.ToEnclosedString(value, enclosure);

			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void EnclosureLength1()
		{
			const string enclosure = "1";
			const string value = "a";
			const string expect = "1a1";
			var actual = Entity.Common.ToEnclosedString(value, enclosure);

			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void EnclosureLength2()
		{
			const string enclosure = "12";
			const string value = "a";
			const string expect = "1a2";
			var actual = Entity.Common.ToEnclosedString(value, enclosure);

			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void EnclosureLength3()
		{
			const string enclosure = "123";
			const string value = "a";
			const string expect = "123a123";
			var actual = Entity.Common.ToEnclosedString(value, enclosure);

			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void StringArray()
		{
			const string enclosure = "12";
			const string separator = ".";
			var value =
				new []
				{
					"a"
					,
					"b"
				}
			;
			const string expect = "1a.b2";
			var actual = Entity.Common.ToEnclosedString(value, enclosure, separator);

			Assert.AreEqual(expect, actual);
		}

	}

}
