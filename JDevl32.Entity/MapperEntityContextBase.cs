using AutoMapper;
using JDevl32.Mapper.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Entity
{

	/// <summary>
	/// An entity context (base class) with (an auto-mapper) mapper.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public abstract class MapperEntityContextBase
		:
		EntityContextBase
		,
		IInstanceMapper
	{

#region Property

#region Implementation of EntityContextBase

		// todo|jdevl32: ???
		/**
		/// <summary>
		/// A logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public new virtual ILogger Logger { get; protected set; }
		/**/

#endregion

#region Implementation of IInstanceMapper

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IMapper Mapper { get; protected set; }

#endregion

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, loggerFactory)
			=>
			//Set(logger, mapper);
			SetMapper(mapper);

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IMapper mapper, string connectionStringKey)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, loggerFactory, connectionStringKey)
			=>
			//Set(logger, mapper);
			SetMapper(mapper);

#endregion

		// todo|jdevl32: ???
		/**
		/// <summary>
		/// Set the logger and mapper.
		/// </summary>
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <param name="mapper">
		/// A mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void Set(ILogger<TDerivedClass> logger, IMapper mapper)
		{
			SetLogger(logger);
			SetMapper(mapper);
		}

		/// <summary>
		/// Set the logger.
		/// </summary>
		/// <param name="logger">
		/// A logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void SetLogger(ILogger<TDerivedClass> logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		/**/

		// todo|jdevl32: is this really needed ???
		/// <summary>
		/// Set the mapper.
		/// </summary>
		/// <param name="mapper">
		/// A mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void SetMapper(IMapper mapper)
		{
			Logger.LogDebug($"[{nameof(mapper)} is {(null == mapper ? string.Empty : "not ")}null]");

			Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

	}

}
