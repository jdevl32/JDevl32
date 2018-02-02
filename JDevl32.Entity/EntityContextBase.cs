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
	/// A entity context (base class).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class EntityContextBase
		:
		DbContext
		,
		IEntityContext
		,
		ILoggable
	{

#region Property

#region Implementation of IEntityContext

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string ConnectionStringKey { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public DbContextOptions DbContextOptions { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Implementation of ILoggable

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual ILogger Logger { get; }

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
		/// The configuration root (of the application).
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting envrionment (of the application).
		/// </param>
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
			:
			base(dbContextOptions)
		{
			ConfigurationRoot = configurationRoot;
			DbContextOptions = dbContextOptions;
			HostingEnvironment = hostingEnvironment;
			Logger = loggerFactory.CreateLogger(GetType());
		}

		/// <inheritdoc />
		/// <summary>
		/// Create an entity context base.
		/// </summary>
		/// <param name="dbContextOptions">
		/// The context options.
		/// </param>
		/// <param name="configurationRoot">
		/// The configuration root (of the application).
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting envrionment (of the application).
		/// </param>
		/// <param name="loggerFactory">
		/// A logger factory.
		/// </param>
		/// <param name="connectionStringKey">
		/// A database connection string key.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, string connectionStringKey)
			:
			this(dbContextOptions, configurationRoot, hostingEnvironment, loggerFactory)
			=>
			ConnectionStringKey = connectionStringKey;

#endregion

#region Implementation of DbContext

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

#region Implementation of IEntityContext

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

#endregion

	}

}
