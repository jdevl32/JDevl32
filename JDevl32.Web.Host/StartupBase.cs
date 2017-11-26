using AutoMapper;
using JDevl32.Entity.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using IStartup = JDevl32.Web.Host.Interface.IStartup;

namespace JDevl32.Web.Host
{

	/// <summary>
	/// An application startup base class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Extend ASP.NET Core Hosting.
	/// </remarks>
	public abstract class StartupBase
		:
		Microsoft.AspNetCore.Hosting.StartupBase
		,
		IStartup
	{

#region Property

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual string ConfigPath { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual bool UseAuthentication { get; } = true;

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual bool UseMvc { get; } = true;

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public virtual bool UseStaticFiles { get; } = true;

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected StartupBase(IHostingEnvironment hostingEnvironment)
			:
			this(hostingEnvironment, @"Config/appsettings.json")
		{
		}

		/// <summary>
		/// Create the startup.
		/// </summary>
		/// <param name="hostingEnvironment">
		/// The hosting environment of the app.
		/// </param>
		/// <param name="configPath">
		/// The configuration file path of the app.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected StartupBase(IHostingEnvironment hostingEnvironment, string configPath)
		{
			ConfigPath = configPath;
			ConfigurationRoot = BuildConfiguration(hostingEnvironment);
			HostingEnvironment = hostingEnvironment;
		}

#endregion

#region Microsoft.AspNetCore.Hosting.StartupBase

		/// <remarks>
		/// Last modification:
		/// Change from protected to public (pull up to interface).
		/// </remarks>
		public override void Configure(IApplicationBuilder applicationBuilder)
		{
			//
			// Order is impoortant:
			// 

			// 1. Static files.
			ConfigureStaticFiles(applicationBuilder);

			// 2. Authentication
			ConfigureAuthentication(applicationBuilder);

			// 3. MVC -- typically last
			ConfigureMVC(applicationBuilder);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public override void ConfigureServices(IServiceCollection services)
		{
			// todo|jdevl32: pre...

			ConfigureEntityContext(services);
			ConfigureIdentity(services);

			// Application cookie is no longer part of identity options (above).
			services.ConfigureApplicationCookie(Configure);

			services.AddLogging();
			services.AddMvc(Configure).AddJsonOptions(Configure);
			services.AddSingleton(ConfigurationRoot);

			// todo|jdevl32: post...

			//// todo|jdevl32: check other environment(s)
			//if (HostingEnvironment.IsDevelopment())
			//{
			//	//services.AddScoped<IMailService, FakeMailService>();
			//} // if
			//else
			//{
			//	// todo|jdevl32: implement real mail service...
			//} // else

			//services.AddScoped<ITravelRepository, TravelRepository>();
			//services.AddTransient<IGeoLocationService, GeoLocationService>();
			//services.AddTransient<ITravelContextSeed, TravelContextSeed>();
		}

#endregion

		protected IConfigurationRoot BuildConfiguration(IHostingEnvironment hostingEnvironment)
		{
			return BuildConfiguration(hostingEnvironment, ConfigPath);
		}

		private static IConfigurationRoot BuildConfiguration(IHostingEnvironment hostingEnvironment, string path)
			=>
			new ConfigurationBuilder()
				.SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile(path)
				.AddEnvironmentVariables()
				.Build();

		protected virtual void Configure(CookieAuthenticationOptions cookieAuthenticationOptions)
		{
			// todo|jdevl32: "api" and login-path need to be virtual properties...
			cookieAuthenticationOptions.Events = new CookieAuthenticationEvents
			{
				// Take over responsibility for redirect to login.
				OnRedirectToLogin = async context =>
				{
					// Only if the request is an API call and response status code ok (200).
					if (context.Request.Path.StartsWithSegments("/api") && 200 == context.Response.StatusCode)
					{
						// Set the response status code to unauthorized (401).
						context.Response.StatusCode = 401;
					} // if
					else
					{
						// Otherwise, simply redirect.
						context.Response.Redirect(context.RedirectUri);
					} // else

					await Task.Yield();
				}
			};
			cookieAuthenticationOptions.LoginPath = "/Auth/Login";
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
		{
			InitializeMapper();
			ConfigureLoggerFactory(applicationBuilder, hostingEnvironment, loggerFactory);
			Configure(applicationBuilder);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IEntityContextSower entityContextSower)
		{
			Configure(applicationBuilder, hostingEnvironment, loggerFactory);

			// Enable/disable as needed (i.e., disable when rebuilding database).
			entityContextSower.Seed().Wait();
		}

		protected virtual void Configure(IdentityOptions identityOptions)
		{
			// todo|jdevl32: constant(s)...
			identityOptions.Password.RequiredLength = 5;
			identityOptions.User.RequireUniqueEmail = true;
		}

		protected virtual void Configure(IMapperConfigurationExpression mapperConfigurationExpression)
		{
			// todo|jdevl32: cleanup...
			//mapperConfigurationExpression.CreateMap<Coordinate, ICoordinate>()
			//	.ConstructUsing(coordinate => new Coordinate( /*coordinate.Latitude, coordinate.Longitude*/))
			//	.ReverseMap();
		}

		protected virtual void Configure(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute
				(
					"Default"
					,
					"{controller}/{action}/{id?}"
					,
					new
					{
						controller = "App",
						action = "Index"
					}
				);
		}

		protected virtual void Configure(MvcJsonOptions mvcJsonOptions)
		{
			mvcJsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		protected virtual void Configure(MvcOptions mvcOptions)
		{
			// todo|jdevl32: HTTPS only required in production ???
			if (HostingEnvironment.IsProduction())
			{
				mvcOptions.Filters.Add(typeof(RequireHttpsAttribute));
			} // if
		}

		protected virtual void ConfigureAuthentication(IApplicationBuilder applicationBuilder)
		{
			if (UseAuthentication)
			{
				// Method "UseIdentity" is obsolete -- this is the replacement.
				applicationBuilder.UseAuthentication();
			} // if
		}

		protected virtual void ConfigureEntityContext(IServiceCollection serviceCollection)
		{
		}

		protected virtual void ConfigureEntityContext<TEntityContext>(IServiceCollection serviceCollection)
			where TEntityContext : DbContext, IEntityContext
			=>
			serviceCollection.AddDbContext<TEntityContext>();

		protected virtual void ConfigureIdentity(IServiceCollection serviceCollection)
		{
		}

		protected virtual void ConfigureIdentity<TIdentityUser, TEntityContext>(IServiceCollection serviceCollection)
			where TEntityContext : DbContext, IEntityContext
			where TIdentityUser : IdentityUser
			=>
			serviceCollection
				.AddIdentity<TIdentityUser, IdentityRole>(Configure)
				.AddEntityFrameworkStores<TEntityContext>();

		protected void ConfigureLoggerFactory(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory) => ConfigureLoggerFactory(applicationBuilder, hostingEnvironment, loggerFactory, LogLevel.Error);

		protected virtual void ConfigureLoggerFactory(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, LogLevel defaultLogLevel)
		{
			if (hostingEnvironment.IsDevelopment())
			{
				defaultLogLevel = LogLevel.Information;
				applicationBuilder.UseDeveloperExceptionPage();
			}

			loggerFactory.AddDebug(defaultLogLevel);
		}

		protected virtual void ConfigureMVC(IApplicationBuilder applicationBuilder)
		{
			if (UseMvc)
			{
				applicationBuilder.UseMvc(Configure);
			} // if
		}

		protected virtual void ConfigureStaticFiles(IApplicationBuilder applicationBuilder)
		{
			if (UseStaticFiles)
			{
				applicationBuilder.UseStaticFiles();
			} // if
		}

		/// <summary>
		/// Initialize and configure auto-mapper mappings.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual void InitializeMapper() => Mapper.Initialize(Configure);

	}

}
