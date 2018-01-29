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
		/// This class should be used to test string representation extension(s).
		/// Last modification:
		/// </remarks>
		public class Test1
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

			/// <summary>
			/// A protected integer value property.
			/// </summary>
			/// <remarks>
			/// This property should not be included in string representation extension(s) (because it is not public).
			/// Last modification:
			/// </remarks>
			protected int ProtectedIntProperty001 { get; } = 1;

			/// <summary>
			/// A private integer value property.
			/// </summary>
			/// <remarks>
			/// This property should not be included in string representation extension(s) (because it is not public).
			/// Last modification:
			/// </remarks>
			private int PrivateIntProperty001 { get; } = 1;

			/// <summary>
			/// A public string property.
			/// </summary>
			/// <remarks>
			/// This property should be included in string representation extension(s) (because it is public).
			/// Last modification:
			/// </remarks>
			public string PublicStringProperty001 { get; } = nameof(PublicStringProperty001);

			/// <summary>
			/// A protected string property.
			/// </summary>
			/// <remarks>
			/// This property should not be included in string representation extension(s) (because it is not public).
			/// Last modification:
			/// </remarks>
			protected string ProtectedStringProperty001 { get; } = nameof(ProtectedStringProperty001);

			/// <summary>
			/// A private string property.
			/// </summary>
			/// <remarks>
			/// This property should not be included in string representation extension(s) (because it is not public).
			/// Last modification:
			/// </remarks>
			private string PrivateStringProperty001 { get; } = nameof(PrivateStringProperty001);

#endregion

		}

	}

}
