using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.TraceListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.Extensions.Logging.Console;
using ProyectoCore.Data;
using ProyectoCore.Models;
using ProyectoCore.Repositories;

namespace ProyectoCore
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //IoC
            String cadenadeconexion = this.configuration.GetConnectionString("cadenahospital");
            String cadenadeconexionmysql = this.configuration.GetConnectionString("cadenahospitalmysql");
            String cadenadeconexionazure = this.configuration.GetConnectionString("cadenahospitalazure");
            //services.AddTransient<RepositoryHospital>();
            //services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadenadeconexion));
            services.AddTransient<IRepositoryHospital, RepositoryHospital>();
            services.AddDbContext<IHospitalContext, HospitalContext>(options => options.UseSqlServer(cadenadeconexionazure));
            //services.AddDbContext<IHospitalContext, HospitalContext>(options => options.UseMySql(cadenadeconexionmysql));

            //services.AddTransient<ICoche, Deportivo>();
            services.AddSingleton<ICoche, Deportivo>(z => new Deportivo("Audi", "A4", "audi.jpg", 300, 0));

            //CONFIGURAMOS EL COMPORTAMIENTO DE LA SESION
            services.AddDistributedMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //DEBEMOS INDICAR QUE ARRANQUE EL SERVICIO DEL 
            //MIDELWARE
            services.AddMvc();
        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddProvider(new ConsoleLoggerProvider((DbLoggerCategory, LogLevel) => LogLevel >= LogLevel.Information, false));
            //loggerFactory.AddConsole(configuration.GetSection("Logging"));
            //ILogger log = loggerFactory.CreateLogger<ConsoleLogger>();
            //log.LogInformation("Mensaje desde StartUp");

            loggerFactory.AddAzureWebAppDiagnostics(new AzureAppServicesDiagnosticsSettings
            {
                OutputTemplate ="{Timestamp:dd-MM-yyyy HH:mm:ss zzz} [{Level}] {RequestId}-{SourceContext}: {Message}{NewLine}{Exception}"
            });
            Trace.Listeners.Add(new ApplicationInsightsTraceListener());
            //1. CONTROL DE ERRORES
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //4. UTILIZAMOS ARCHIVOS DE wwwroot
            app.UseStaticFiles();
            //5. POLITICA DE COOKIES
            app.UseCookiePolicy();
            //7. UTILIZAMOS LA SESION
            app.UseSession();
            //8. DEBEMOS DAR LA RUTA DE INICIO
            //CONFIGURAMOS LAS AREAS
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=RealMadrid}/{action=Index}/{id?}"
                );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
