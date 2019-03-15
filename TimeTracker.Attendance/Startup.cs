using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeTracker.Attendance.Components;
using TimeTracker.Data;
using TimeTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Attendance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add data context
            services.AddDbContextPool<TimeTrackerContext>(options =>
                                                          options.UseLazyLoadingProxies()
                                                                 .EnableSensitiveDataLogging(true) // TODO: Perhaps use a flag from appsettings instead of a hard-coded value
                                                                 .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMvc()
                    .AddNewtonsoftJson();

            services.AddRazorComponents();

            services.AddTransient<Service>();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<App>("app");
            });
        }
    }
}
