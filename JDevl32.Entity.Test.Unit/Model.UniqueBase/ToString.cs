using JDevl32.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JDevl32.Entity.Test.Unit.Model.UniqueBase
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
			var uniqueBase = new Implementation.UniqueBase
			{
				Description = Implementation.Description
				,
				FullName = Implementation.FullName
				,
				Id = Implementation.IdValue
				,
				ShortName = Implementation.ShortName
			}
			;
			var expect = typeof(Entity.Model.UniqueBase).ToString();

			// todo|jdevl32: ??? why (logger) not working ???
			Logger.Instance.LogDebug($"[{nameof(expect)}={expect}]");
			Logger.Instance.LogDebug($"[{nameof(uniqueBase)}={uniqueBase}]");

			Assert.AreNotEqual(expect, uniqueBase.ToString());
		}

	}

}
