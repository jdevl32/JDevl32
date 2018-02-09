using JDevl32.Entity.Generic;

namespace JDevl32.Entity.Test.Unit
{

	/// <summary>
	/// Container class for required implementation class(es) for testing.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public static partial class Implementation
	{

		/// <summary>
		/// A test (implementation) class.
		/// </summary>
		/// <remarks>
		/// This class should be used to test string representation extension(s) of integer unique entity item(s).
		/// Last modification:
		/// </remarks>
		public class UniqueIntEntityBase
			:
			UniqueEntityBase<int>
		{

#region Property

			/// <summary>
			/// A public integer value property.
			/// </summary>
			/// <remarks>
			/// This property should be included in string representation extension(s) (because it is public).
			/// Last modification:
			/// </remarks>
			public int PublicIntProperty001 { get; } = 1;

#endregion

		}

	}

}
