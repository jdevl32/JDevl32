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
		public virtual string ConnectionStringKey { get; }

		/// <inheritdoc />
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create an entity context base.
		/// </summary>
		/// <param name="dbContextOptions">
		/// The context options.
		/// </param>
		/// <param name="configurationRoot">
		/// The configuration root of the application.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting envrionment of the application.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment)
			:
			base(dbContextOptions)
		{
			ConfigurationRoot = configurationRoot;
			HostingEnvironment = hostingEnvironment;
		}

#endregion

#region DbContext

		/// <inheritdoc />
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (HostingEnvironment.IsDevelopment())
			{
				optionsBuilder.EnableSensitiveDataLogging();
			} // if

			if (!string.IsNullOrWhiteSpace(ConnectionStringKey))
			{
				optionsBuilder.UseSqlServer(ConfigurationRoot[ConnectionStringKey]);
			} // if
		}

		///// <inheritdoc />
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//}

#endregion

	}

}
