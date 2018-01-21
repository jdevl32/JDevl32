using JDevl32.Entity.Interface;
using JDevl32.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JDevl32.Entity.Test.Unit.Common
{

	/// <summary>
	/// ToString test.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	[TestClass]
	public class ToString
	{

#region Constant

#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[TestMethod]
		public void IsNotBase()
		{
			var mock = new Mock<IUnique>();
			mock
				.SetupProperty(p => p.Id, Implementation.IdValue)
				.SetupProperty(p => p.Description, Implementation.Description)
				.SetupProperty(p => p.FullName, Implementation.FullName)
				.SetupProperty(p => p.ShortName, Implementation.ShortName)
			;
			var uniqueItem = mock.Object;
			var expect = typeof(IUnique).ToString();

			// todo|jdevl32: ??? why (logger) not working ???
			Logger.Instance.LogDebug($"[{nameof(expect)}={expect}]");
			Logger.Instance.LogDebug($"[{nameof(uniqueItem)}={uniqueItem}]");

			Assert.AreNotEqual(expect, Extension.IUnique.ToString(uniqueItem));
		}

	}

}
