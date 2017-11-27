﻿using JDevl32.Entity.Interface;
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
	/// Add database context options.
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
		public DbContextOptions DbContextOptions { get; }

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
			DbContextOptions = dbContextOptions;
			HostingEnvironment = hostingEnvironment;
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
		/// <param name="connectionStringKey">
		/// The database connection string key.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected EntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, string connectionStringKey)
			:
			this(dbContextOptions, configurationRoot, hostingEnvironment) => ConnectionStringKey = connectionStringKey;

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
