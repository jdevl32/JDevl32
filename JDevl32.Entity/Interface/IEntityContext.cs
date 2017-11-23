using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace JDevl32.Entity.Interface
{

	/// <summary>
	/// The entity context.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IEntityContext
	{

#region Property

		/// <summary>
		/// The configuration root of the application.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IConfigurationRoot ConfigurationRoot { get; }

		/// <summary>
		/// The database connection string key.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string ConnectionStringKey { get; }

		/// <summary>
		/// The hosting environment of the application.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IHostingEnvironment HostingEnvironment { get; }

#endregion

	}

}
