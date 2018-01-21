using JDevl32.Entity.Interface;

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

#region Constant

		public const string Id = nameof(Id);

		public const int IdValue = 1;

		public const string Description = nameof(Description);

		public const string FullName = nameof(FullName);

		public const string ShortName = nameof(ShortName);

#endregion

		/// <inheritdoc />
		/// <summary>
		/// An implementation class to test the unique item interface.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public class Unique
			:
			IUnique
		{

#region IUnique

			/// <inheritdoc />
			/// <remarks>
			/// Last modification:
			/// </remarks>
			public int Id { get; set; } = IdValue;

			/// <inheritdoc />
			/// <remarks>
			/// Last modification:
			/// </remarks>
			public string ShortName { get; set; } = Implementation.ShortName;

			/// <inheritdoc />
			/// <remarks>
			/// Last modification:
			/// </remarks>
			public string FullName { get; set; } = Implementation.FullName;

			/// <inheritdoc />
			/// <remarks>
			/// Last modification:
			/// </remarks>
			public string Description { get; set; } = Implementation.Description;

#endregion

			// todo|jdevl32: ???
			///// <summary>
			///// The base implementation of the string value of a unique item.
			///// </summary>
			///// <returns>
			///// The base implementation of the string value of a unique item.
			///// </returns>
			///// <remarks>
			///// Last modification:
			///// </remarks>
			//public string ToStringBase() => GetType().ToString();

		}

	}

}
