using AutoMapper;
using JDevl32.Mapper.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace JDevl32.Entity.Generic
{

	/// <summary>
	/// A (generic) entity context (base class) with a(n) (auto-mapper) mapper.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// (Re-)implement as generic.
	/// </remarks>
	public abstract class MapperEntityContextBase<TDerivedClass>
		:
		EntityContextBase<TDerivedClass>
		,
		IInstanceMapper
		where
			TDerivedClass
			:
			class
	{

#region Property

#region IInstanceMapper

		/// <summary>
		/// The logger.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Make virtual.
		/// </remarks>
		public new virtual ILogger<TDerivedClass> Logger { get; protected set; }

		/// <inheritdoc />
		public IMapper Mapper { get; protected set; }

#endregion

#endregion

#region Instance Initialization

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, logger)
			=>
			Set(logger, mapper);

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, IMapper mapper, string connectionStringKey)
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
		protected virtual void Set(ILogger<TDerivedClass> logger, IMapper mapper)
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
		protected virtual void SetLogger(ILogger<TDerivedClass> logger)
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
