using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JDevl32.Web.Host.Interface
{

	/// <summary>
	/// An application startup.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Remove:  Extend ASP.NET Core Hosting.
	/// </remarks>
	public interface IStartup
	{

#region Property

		/// <summary>
		/// The config (.json file) path.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string ConfigPath { get; }

		/// <summary>
		/// The configuration root of the app.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IConfigurationRoot ConfigurationRoot { get; }

		/// <summary>
		/// The hosting environment of the app.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IHostingEnvironment HostingEnvironment { get; }

		/// <summary>
		/// Flag to use authentication.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		bool UseAuthentication { get; }

		/// <summary>
		/// Flag to use MVC.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		bool UseMvc { get; }

		/// <summary>
		/// Flag to use static files.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		bool UseStaticFiles { get; }

#endregion

		/// <summary>
		/// Configure services for the application.
		/// </summary>
		/// <param name="services">
		/// The services to configure.
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		/// For more information on Core 1.x -> 2.x migration, visit https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/identity-2x
		/// Last modification:
		/// </remarks>
		void ConfigureServices(IServiceCollection services);

		/// <summary>
		/// Configure the startup (using the application builder).
		/// </summary>
		/// <param name="applicationBuilder">
		/// The application builder.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Pull up from base class implementation.
		/// </remarks>
		void ConfigureStartup(IApplicationBuilder applicationBuilder);

		/// <summary>
		/// Configure the startup.
		/// </summary>
		/// <param name="applicationBuilder">
		/// The application builder.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting environment.
		/// </param>
		/// <param name="loggerFactory">
		/// The logger factory.
		/// </param>
		/// <remarks>
		/// Use this method to configure the HTTP request pipeline.
		/// Last modification:
		/// Rename (to avoid possible collisions).
		/// </remarks>
		void ConfigureStartup(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory);

		// todo|jdevl32: ???
		/**
		/// <summary>
		/// Configure the application.
		/// </summary>
		/// <param name="applicationBuilder">
		/// The application builder.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting environment.
		/// </param>
		/// <param name="loggerFactory">
		/// The logger factory.
		/// </param>
		/// <param name="entityContextSower">
		/// The travel database context seeder.
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// Last modification:
		/// Configure authentication.
		/// </remarks>
		void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IEntityContextSower entityContextSower);
		**/

	}

}
