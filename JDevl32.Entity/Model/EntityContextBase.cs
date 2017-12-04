﻿using JDevl32.Entity.Interface;
using JDevl32.Logging.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JDevl32.Entity.Model
{

	/// <summary>
	/// The entity context base class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Re-implement generic entity context interface as non-generic.
	/// Implement as loggable interface.
	/// </remarks>
	public abstract class EntityContextBase
		:
		DbContext
		,
		IEntityContext
		,
		ILoggable<EntityContextBase>
	{

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
		public virtual ILogger<EntityContextBase> Logger { get; }

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
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<EntityContextBase> logger)
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
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<EntityContextBase> logger, string connectionStringKey)
			:
			this(dbContextOptions, configurationRoot, hostingEnvironment, logger) => ConnectionStringKey = connectionStringKey;

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

#endregion

	}

}
