using AutoMapper;
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
using System;
using System.Threading.Tasks;
using IStartup = JDevl32.Web.Host.Interface.IStartup;

namespace JDevl32.Web.Host
{

	/// <summary>
	/// An application startup base class.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Rename (some) configure methods (to avoid collision).
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

		/// <summary>
		/// The action to configure auto-mapper.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<IMapperConfigurationExpression> ConfigureAutoMapperAction
			=>
			mapperConfigurationExpression => ConfigureAutoMapper(mapperConfigurationExpression);

		/// <summary>
		/// The action to configure the application cookie(s).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<CookieAuthenticationOptions> ConfigureCookieAuthenticationAction
			=>
			cookieAuthenticationOptions => ConfigureCookieAuthentication(cookieAuthenticationOptions);

		/// <summary>
		/// The action to configure identity.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<IdentityOptions> ConfigureIdentityAction
			=>
			identityOptions => ConfigureIdentity(identityOptions);

		/// <summary>
		/// The action to configure JSON.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<MvcJsonOptions> ConfigureJSONAction
			=>
			mvcJsonOptions => ConfigureJSON(mvcJsonOptions);

		/// <summary>
		/// The action to configure MVC.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<MvcOptions> ConfigureMVCAction
			=>
			mvcOptions => ConfigureMVC(mvcOptions);

		/// <summary>
		/// The action to configure routes.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected virtual Action<IRouteBuilder> ConfigureRoutesAction
			=>
			routeBuilder => ConfigureRoutes(routeBuilder);

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
		/// Re-implement configure methods as virtual actions.
		/// </remarks>
		public override void ConfigureServices(IServiceCollection services)
		{
			// todo|jdevl32: pre...

			ConfigureEntityContext(services);
			// todo|jdevl32: dependent on use-auth (or new add-auth) ???
			ConfigureIdentity(services);

			// Application cookie is no longer part of identity options (above).
			services.ConfigureApplicationCookie(ConfigureCookieAuthenticationAction);

			services.AddLogging();
			// todo|jdevl32: dependent on use-mvc (or new add-mvc) ???
			services.AddMvc(ConfigureMVCAction).AddJsonOptions(ConfigureJSONAction);
			services.AddSingleton(ConfigurationRoot);
			// todo|jdevl32: dependent on mvc (would need to add if not use/add-mvc, or exception) ???
			services.AddAutoMapper();

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

		// todo|jdevl32: ???
		/**
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
		**/

		protected virtual void ConfigureAuthentication(IApplicationBuilder applicationBuilder)
		{
			if (UseAuthentication)
			{
				// Method "UseIdentity" is obsolete -- this is the replacement.
				applicationBuilder.UseAuthentication();
			} // if
		}

		/// <summary>
		/// Configure auto-mapper.
		/// </summary>
		/// <param name="mapperConfigurationExpression">
		/// The mapper configuration expression.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureAutoMapper(IMapperConfigurationExpression mapperConfigurationExpression)
		{
			// todo|jdevl32: cleanup...
			//mapperConfigurationExpression.CreateMap<Coordinate, ICoordinate>()
			//	.ConstructUsing(coordinate => new Coordinate( /*coordinate.Latitude, coordinate.Longitude*/))
			//	.ReverseMap();
		}

		/// <summary>
		/// Configure cookie authentication.
		/// </summary>
		/// <param name="cookieAuthenticationOptions">
		/// The cookie authentication options.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureCookieAuthentication(CookieAuthenticationOptions cookieAuthenticationOptions)
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

		protected virtual void ConfigureEntityContext(IServiceCollection serviceCollection)
		{
		}

		// todo|jdevl32: ???
		/**
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntityContext">
		/// The entity context type.
		/// </typeparam>
		/// <param name="serviceCollection">
		/// The service collection.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Remove some restrictions on type params.
		/// </remarks>
		protected virtual void ConfigureEntityContext<TEntityContext>(IServiceCollection serviceCollection)
			where
				TEntityContext
				:
				DbContext
				//,
				//IEntityContext
			=>
			serviceCollection.AddDbContext<TEntityContext>();

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntityContext">
		/// The entity context type.
		/// </typeparam>
		/// <typeparam name="TDerivedClass">
		/// The (loggable) derived class type.
		/// </typeparam>
		/// <param name="serviceCollection">
		/// The service collection.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Remove generic entity context interface -- obsolete due to (new) loggable interface.
		/// Re-implement logger downstream (due to loggable interface).
		/// </remarks>
		protected virtual void ConfigureEntityContext<TEntityContext, TDerivedClass>(IServiceCollection serviceCollection)
			where TDerivedClass : class
			where
				TEntityContext
				:
				DbContext
				,
				IEntityContext
				,
				ILoggable<TDerivedClass>
			=>
			serviceCollection.AddDbContext<TEntityContext>();
		**/

		/// <summary>
		/// Configure identity.
		/// </summary>
		/// <param name="identityOptions">
		/// The identity options.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureIdentity(IdentityOptions identityOptions)
		{
			// todo|jdevl32: constant(s)...
			identityOptions.Password.RequiredLength = 5;
			identityOptions.User.RequireUniqueEmail = true;
		}

		protected virtual void ConfigureIdentity(IServiceCollection serviceCollection)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TIdentityUser">
		/// 
		/// </typeparam>
		/// <typeparam name="TEntityContext">
		/// 
		/// </typeparam>
		/// <param name="serviceCollection">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Re-implement configure methods as virtual actions.
		/// </remarks>
		protected virtual void ConfigureIdentity<TIdentityUser, TEntityContext>(IServiceCollection serviceCollection)
			where
				TEntityContext
				:
				DbContext
				//,
				//IEntityContext
			where
				TIdentityUser
				:
				IdentityUser
			=>
			serviceCollection
				.AddIdentity<TIdentityUser, IdentityRole>(ConfigureIdentityAction)
				.AddEntityFrameworkStores<TEntityContext>();

		/// <summary>
		/// Configure JSON.
		/// </summary>
		/// <param name="mvcJsonOptions">
		/// The JSON options.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureJSON(MvcJsonOptions mvcJsonOptions)
		{
			mvcJsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

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

		/// <summary>
		/// Configure MVC.
		/// </summary>
		/// <param name="applicationBuilder">
		/// An application builder.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Re-implement configure methods as virtual actions.
		/// </remarks>
		protected virtual void ConfigureMVC(IApplicationBuilder applicationBuilder)
		{
			if (UseMvc)
			{
				applicationBuilder.UseMvc(ConfigureRoutesAction);
			} // if
		}

		/// <summary>
		/// Configure MVC.
		/// </summary>
		/// <param name="mvcOptions">
		/// The MVC options.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureMVC(MvcOptions mvcOptions)
		{
			// todo|jdevl32: HTTPS only required in production ???
			if (HostingEnvironment.IsProduction())
			{
				mvcOptions.Filters.Add(typeof(RequireHttpsAttribute));
			} // if
		}

		/// <summary>
		/// Configure route(s).
		/// </summary>
		/// <param name="routeBuilder">
		/// The route builder.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		protected virtual void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			// todo|jdevl32: need to be virtual properties...
			routeBuilder.MapRoute
				(
					"Default"
					,
					"{controller}/{action}/{id?}"
					,
					new
					{
						controller = "App"
						,
						action = "Index"
					}
				);
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
		/// Re-implement configure methods as virtual actions.
		/// </remarks>
		protected virtual void InitializeMapper() => AutoMapper.Mapper.Initialize(ConfigureAutoMapperAction);

	}

}
