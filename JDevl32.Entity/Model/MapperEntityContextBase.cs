using AutoMapper;
using JDevl32.Mapper.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Entity.Model
{

	/// <summary>
	/// An entity context base class with (an auto-mapper) mapper.
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

#region IInstanceMapper

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Implement set mapper.
		/// </remarks>
		public new ILogger<MapperEntityContextBase> Logger { get; protected set; }

		/// <inheritdoc />
		public IMapper Mapper { get; protected set; }

#endregion

#endregion

#region Instance Initialization

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<MapperEntityContextBase> logger, IMapper mapper)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, logger)
			=>
			Set(logger, mapper);

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<MapperEntityContextBase> logger, IMapper mapper, string connectionStringKey)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, logger, connectionStringKey)
			=>
			Set(logger, mapper);

#endregion

		/// <summary>
		/// Set the logger and mapper.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="mapper">
		/// The mapper.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void Set<TDerivedClass>(ILogger<TDerivedClass> logger, IMapper mapper)
			where TDerivedClass : MapperEntityContextBase
		{
			SetLogger(logger);
			SetMapper(mapper);
		}

		/// <summary>
		/// Set the logger.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void SetLogger<TDerivedClass>(ILogger<TDerivedClass> logger)
			where TDerivedClass : MapperEntityContextBase
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <summary>
		/// Set the mapper.
		/// </summary>
		/// <param name="mapper">
		/// The mapper.
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
