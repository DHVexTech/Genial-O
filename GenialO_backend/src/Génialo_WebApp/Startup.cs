using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GenialO.WebApp
{
    public class Startup
    {
        public Startup( IHostingEnvironment env )
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath( env.ContentRootPath )
                .AddJsonFile( "appsettings.json", optional: true )
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddOptions();

            

            services.AddMvc();
            
        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory )
        {
            loggerFactory.AddConsole();

            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" } );

                routes.MapRoute(
                    name: "spa-fallback",
                    template: "Home/{*anything}",
                    defaults: new { controller = "Home", action = "Index" } );
            } );

            app.UseStaticFiles();
        }
    }
}
