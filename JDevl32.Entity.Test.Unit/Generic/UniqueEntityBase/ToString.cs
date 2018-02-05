using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JDevl32.Entity.Test.Unit.Generic.UniqueEntityBase
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	[TestClass]
	public class ToString
	{

#region Property

		/// <summary>
		/// A test implementation object.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public static Implementation.IntUniqueEntityBase IntUniqueEntityBase { get; private set; }

#endregion

		/// <summary>
		/// The test initialization method.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[TestInitialize]
		public void Initialize()
		{
			IntUniqueEntityBase = new Implementation.IntUniqueEntityBase
			{
				Id = 11
				,
				ShortName = "test short name"
				,
				FullName = "test full name"
				,
				Description = "test description"
			}
			;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[TestMethod]
		public void IsExtension()
		{
			var test = IntUniqueEntityBase;
			// todo|jdevl32: ???
			var expect = $"[{test.GetType()}:{Entity.Common.ToPropertyString(test)}]";
			var actual = test.ToString();

			Assert.AreEqual(expect, actual);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[TestMethod]
		public void IsNotBase()
		{
			var test = IntUniqueEntityBase;
			var notExpect = test.GetType().ToString();
			var actual = test.ToString();

			Assert.AreNotEqual(notExpect, actual);
		}

	}

}
