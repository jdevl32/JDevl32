using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JDevl32.Entity
{

	/// <summary>
	/// A (generic) entity context (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add save changes async.
	/// </remarks>
	public abstract class EntityContextBase<TDerivedClass>
		:
		DbContext
		,
		IEntityContext
		,
		ILoggable<TDerivedClass>
		where
			TDerivedClass
			:
			class
	{

#region Property

#region IEntityContext

		/// <inheritdoc />
		public IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		public virtual string ConnectionStringKey { get; }

		/// <inheritdoc />
		public DbContextOptions DbContextOptions { get; }

		/// <inheritdoc />
		public IHostingEnvironment HostingEnvironment { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Make virtual (due to re-implementation).
		/// </remarks>
		public virtual ILogger<TDerivedClass> Logger { get; }

#endregion

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
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger)
			:
			base(dbContextOptions)
		{
			ConfigurationRoot = configurationRoot;
			DbContextOptions = dbContextOptions;
			HostingEnvironment = hostingEnvironment;
			Logger = logger;
		}

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
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="connectionStringKey">
		/// The database connection string key.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, string connectionStringKey)
			:
			this(dbContextOptions, configurationRoot, hostingEnvironment, logger) => ConnectionStringKey = connectionStringKey;

#endregion

#region DbContext

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
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

#endregion

#region IEntityContext

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

#endregion

	}

}
