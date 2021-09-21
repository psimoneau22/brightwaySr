using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews();

            services.Configure<TravelSettings>(Configuration.GetSection(TravelSettings.AppSettingName));

            services.AddDbContext<TravelDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(Databases.TravelDB.AppSettingName)));

            services.AddHttpClient<ExchangeProxy>(client => {
                var config = Configuration.GetSection(ExchangeProxy.AppSettingName);
                client.BaseAddress = new System.Uri(config.GetValue<string>("BaseAddress"));
            });

            services.AddTransient<CountryRepository>();
            services.AddTransient<BookingRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // anything at /api will use API controllers
            app.Map("/api", true, app => {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            // everything else will be served the spa
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapFallbackToController("Index", "Home");
            });
        }
    }
}
