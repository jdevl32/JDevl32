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
		public new ILogger<MapperEntityContextBase> Logger { get; }

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
			SetMapper(mapper);

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, ILogger<MapperEntityContextBase> logger, IMapper mapper, string connectionStringKey)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, logger, connectionStringKey)
			=>
			SetMapper(mapper);

#endregion

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
