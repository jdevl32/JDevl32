using JDevl32.Entity.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JDevl32.Entity.Model
{

	/// <summary>
	/// The entity context base class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextBase
		:
		DbContext
		,
		IEntityContext
	{

#region IEntityContext

		/// <inheritdoc />
		public IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create an entity context base.
		/// </summary>
		/// <param name="configurationRoot">
		/// The configuration root of the application.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting envrionment of the application.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment)
		{
			ConfigurationRoot = configurationRoot;
			HostingEnvironment = hostingEnvironment;
		}

#endregion

	}

}
