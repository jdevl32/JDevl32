using AutoMapper;
using JDevl32.Mapper.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

		/// <inheritdoc />
		public IMapper Mapper { get; }

#endregion

#endregion

#region Instance Initialization

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, IMapper mapper)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment)
			=>
			Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

		/// <inheritdoc />
		protected MapperEntityContextBase(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment, IMapper mapper, string connectionStringKey)
			:
			base(dbContextOptions, configurationRoot, hostingEnvironment, connectionStringKey)
			=>
			Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

#endregion

	}

}
